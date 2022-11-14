var app = getApp(),
  utils = require("../../utils/util");
  var e = null;
  var openid = "";
Page({
  data: {
    data: [],
    classArray: [],
    classIndex: 0,
    shareShow: !1,
    cid: ""
  },
  // 打开即执行
  onLoad: function onLoad(query) {
    var that = this;
    // 读取用户的openid
    wx.getStorage({
      key: 'openid',
      success (res) {
        console.log("缓存的openid："+res.data)
        openid = res.data+"";
      }
    })
    this.getClassDatas();
  },
  getClassDatas: function getClassDatas() {
    wx.login({
      success: function success(code) {
        console.log("启动了小程序"+openid);
        utils.getRequest("/Api/classDatas.php?code=" + code.code + "&openid=" + openid).then(function (res) {
          console.log(res);
          if (res.data.code == 200) {
            that.setData({
              data: res.data.data,
              classArray: res.data.class,
              cid: res.data.class[0].cid
            });
            wx.setNavigationBarTitle({
              title: res.data.data.xcx_name
            });
            // 缓存用户的openid
            wx.setStorage({
              key:"openid",
              data: res.data.data.openid
            })
            console.log("新缓存的openid："+res.data.data.openid)
            //扫码检测登录
            const scene = decodeURIComponent(query.scene)+"";
            console.log("收到的启动参数--" + scene);
            if(scene != "undefined"){
              wx.login({
                success: function success(code) {
                  wx.showLoading({title: "正在登录"})
                }
              });
            }else{
              console.log("无需登录");
              wx.showToast({title: "数据加载完成",duration: 1000});
            }

          } else {
            wx.showModal({
              title: "提示",
              content: res.data.msg,
              showCancel: !1,
              confirmText: "重试",
              success: function success() {
                that.getClassDatas();
              }
            });
          }
        }).catch(function (res) {
          console.log(res);
          wx.showModal({
            title: "提示",
            content: "网络请求超时01" + res,
            confirmText: "重试",
            success: function success() {
              that.getClassDatas();
            }
          });
        });
      }
    });
  },



  // 选择模块
  classChange: function classChange(e) {
    var cid = this.data.classArray[e.detail.value].cid;
    console.log("选的是", e.detail.value);
    console.log("选的名称", this.data.classArray[e.detail.value].name);
    console.log("选的名称ID", cid);
    this.setData({
      classIndex: e.detail.value,
      cid: cid
    });
  },
  receive: function receive() {
    var that = this;
    switch (that.data.data.examine) {
      case 0:
        that.ok();
        break;

      case 1:
        that.submitPay();
        break;

      case 2:
        this.initVideoAd(function () {
          that.ok();
        });
        break;

      case 3:
        this.initVideoAd(function () {
          that.setData({
            shareShow: !0
          });
        });
        break;

      default:
        that.ok();
    }
  },
  popupShow: function popupShow() {
    this.setData({
      shareShow: !1
    });
  },
  ok: function ok(trade_no) {

      var that = this;
      wx.showLoading({
        title: "领取奖励中"
      });
      wx.login({
        success: function success(code) {
          utils.getRequest("/Api/getCarmel.php?code=" + code.code + "&cid=" + that.data.cid + "&trade_no=" + trade_no + "&openid=" + openid).then(function (res) {
            console.log(res);
            wx.hideLoading();
            if (res.data.code == 200) {
              // 成功了

              console.log("领取成功辣");

              wx.showToast({
                title: "奖励领取成功！",
                duration: 3000
              });

              wx.switchTab({
                url: 'pages/record/record'
              })


              wx.showModal({
                title: "领取成功",
                content: res.data.carmel,
                showCancel: !1,
                confirmText: "我知道了",
                success: function success() {
                  that.setData({
                    shareShow: !1
                  });
                }
              });

            } else {
              wx.showModal({
                title: "提示",
                content: res.data.msg,
                showCancel: !1,
                confirmText: "我知道了",
                success: function success() {
                  that.setData({
                    shareShow: !1
                  });
                }
              });
            }

          }).catch(function (res) {
            wx.showModal({
              title: "提示",
              content: "网络请求超时02",
              confirmText: "重试",
              success: function success() {
                that.setData({
                  shareShow: !1
                });
                that.getClassDatas();
              }
            });
          });
        },
        fail: function fail(eer) {
          wx.showModal({
            title: "提示",
            content: "网络请求超时03",
            confirmText: "重试",
            success: function success() {
              that.setData({
                shareShow: !1
              });
              that.getClassDatas();
            }
          });
        }
      });

  },

// 视频判断
  initVideoAd: function initVideoAd(t) {
    var o = this;
    this.openVideoAd(function () {
      t();
    }, function () {
      if (o.data.data.examine == 1) {
        t();
        return;
      }
      wx.showModal({
        title: "提示",
        content: o.data.data.adVideoTip,
        showCancel: !1
      });


    }, function () {
      wx.showToast({
        title: '广告播放失败',
        icon: 'error',
        duration: 2000
      })

    });
  },
  // 广告播放
  openVideoAd: function openVideoAd(t, o, a) {
    wx.createRewardedVideoAd ? (
      wx.showLoading({
        title: "正在加载广告"
      }), e && (e.offClose(), e.offError(), e.offLoad()), (e = wx.createRewardedVideoAd({
        adUnitId: this.data.data.adVideoId ? this.data.data.adVideoId : "adunit-5c5db30d5db5319e"
      })).load().then(function () {
        wx.hideLoading(), e.onClose(function (a) {
          a && a.isEnded ? t && t() : (o && o(), console.log("播放中途退出"));
        }), e.show();
      }).catch(function (t) {
        wx.hideLoading();
      }), e.onLoad(function () {
        wx.hideLoading(), 
        console.log("video 视频加载成功");

        console.log("视频状态解开");
      }), e.onError(function (t) {
        wx.hideLoading(), a && a(), console.log(t);
      })) : wx.showModal({
      title: "提示",
      content: "您的微信版本过低，不支持此功能，请升级。"
    });

  },
  onShareAppMessage: function onShareAppMessage() {
    return {
      title: this.data.data.shareTitle ? this.data.data.shareTitle : "极狐游戏加速器",
      path: "/pages/index/index",
      imageUrl: this.data.data.shareImg ? this.data.data.shareImg : "../../img/share.jpg",
      success: function success(t) {
        wx.showToast({
          title: "分享成功",
          icon: "success",
          duration: 2e3
        });
      },
      fail: function fail(t) {
        wx.showToast({
          title: "分享失败",
          icon: "none",
          duration: 2e3
        });
      }
    };
  }
});