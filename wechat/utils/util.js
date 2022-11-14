function getRequest(url) {
    var that = this;
    return new Promise(function(resolve, reject) {
        wx.request({
            url: getApp().globalData.request_url + url,
            header: {
                "content-type": "application/x-www-form-urlencoded"
            },
            method: "GET",
            success: function success(res) {
                resolve(res);
            },
            fail: function fail(res) {
                reject(res);
                //Promise返回失败
                        }
        });
    });
}

function buildOrderNo() {
    var now = new Date();
    var year = now.getFullYear();
    var month = now.getMonth() + 1;
    var day = now.getDate();
    var hour = now.getHours();
    var minutes = now.getMinutes();
    var seconds = now.getSeconds();
    String(month).length < 2 ? month = Number("0" + month) : month;
    String(day).length < 2 ? day = Number("0" + day) : day;
    String(hour).length < 2 ? hour = Number("0" + hour) : hour;
    String(minutes).length < 2 ? minutes = Number("0" + minutes) : minutes;
    String(seconds).length < 2 ? seconds = Number("0" + seconds) : seconds;
    var yyyyMMddHHmmss = "" + year + month + day + hour + minutes + seconds;
    var outTradeNo = yyyyMMddHHmmss + "_" + Math.random().toString(36).substr(2, 9);
    console.log(outTradeNo);
    return outTradeNo;
}

module.exports = {
    getRequest: getRequest,
    buildOrderNo: buildOrderNo
};