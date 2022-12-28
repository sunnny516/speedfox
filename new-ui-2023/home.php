<!-- 
       　  　▃▆█▇▄▖
　 　 　 ▟◤▖　　　◥█▎
   　 ◢◤　 ▐　　　 　▐▉
　 ▗◤　　　▂　▗▖　　▕█▎
　◤　▗▅▖◥▄　▀◣　　█▊
▐　▕▎◥▖◣◤　　　　◢██
█◣　◥▅█▀　　　　▐██◤
▐█▙▂　　     　◢██◤
◥██◣　　　　◢▄◤
 　　▀██▅▇▀


为什么要看我的屎代码
 -->


<title>主页</title>
<link rel="stylesheet" href="src/mdui/css/mdui.min.css" />
<link rel="stylesheet" href="src/css/home.css?<?echo time()?>" />
        <style>
            body {
                background-color: #303030;
            }
        </style>
<load style="width: 100%;height: 100%;background: #141414;position: fixed;z-index: 99999;">
    <img src="src/img/logo-1.png" height="200px"style="left: 50%;top: 50%;transform: translate(-50%,-50%);position: absolute;">
</load>
<body class="mdui-theme-primary-indigo mdui-theme-accent-indigo mdui-theme-layout-dark mdui-theme-primary-blue" style="overflow-x:hidden">
    <!-- 顶部常驻工具栏 -->
    <div class="mdui-appbar" style="z-index: 9999;position: fixed;top: 0;width: 100%;">
      <div class="mdui-toolbar mdui-color-theme" style="height: 64px;background-color: #212121ed!important;">
        <a href="javascript:;" class="mdui-typo-title">
            <img src="src/img/logo-1.png" height="98%">
            
<text style="
    position: absolute;
    top: -12px;
    left: 86px;
    font-size: 12px;
"><t style="
    background: rgb(238, 191, 49);
    padding: 2px 5px;
    border-radius: 4px;
">开发版</t></text>
            
        </a>
        
        
        <div class="mdui-toolbar-spacer"></div>
        

        <a href="javascript:;" class="mdui-btn mdui-btn-icon">
          <i class="mdui-icon material-icons">&#xe7f4;</i>
        </a>
        
        
        <a href="javascript:;" class="mdui-btn mdui-btn-icon" style="padding: 6px;" onclick="MenuButton('menu_settings')">
          <!--<img src="/ui/src/img/avater_box/test_avater_02.png" style="position: absolute;width: 48px;left: 0px;top: 0px;"> -->
          <img src="src/img/logo-1.png" style="border-radius: 99px;height: 100%;background: #4a4a4a;">
        </a>
      </div>
      
      <!-- 加载进度条  -->
      <!-- 
      <div class="mdui-progress">
        <div class="mdui-progress-indeterminate"></div>
      </div>
       -->
    </div>
    
    <!-- 侧面大菜单 -->
    <div class="mdui-drawer-fox" style="top: 64px;background: #48484875;">
        <ul class="mdui-list">
           
          
          
          
          
          <li class="mdui-list-item mdui-ripple menu_Selected_N" id="menu_dashboard" onclick="MenuButton('menu_dashboard')">
            <i class="mdui-list-item-icon-fox mdui-icon material-icons">view_quilt</i>
            <div class="mdui-list-item-content">仪表盘</div>
          </li>
          <li class="mdui-list-item mdui-ripple menu_Selected_N gamelist_left_bottom" id="menu_game" onclick="MenuButton('menu_game')">
            <i class="mdui-list-item-icon-fox mdui-icon material-icons">gamepad</i>
            <div class="mdui-list-item-content">游戏</div>
          </li>
          <li class="mdui-list-item mdui-ripple menu_Selected_N gamelist_left_bottom" id="menu_restore" onclick="MenuButton('menu_restore')">
            <i class="mdui-list-item-icon-fox mdui-icon material-icons">restore</i>
            <div class="mdui-list-item-content">历史</div>
          </li>
          
          
          <!--<li class="mdui-list-item mdui-ripple menu_Selected_N" id="waishe" onclick=" Notiflix.Notify.Info('极狐外设还在开发中,极狐外设会推出鼠标键盘等设备,敬请期待~');">-->
          <!--  <i class="mdui-list-item-icon-fox mdui-icon material-icons">usb</i>-->
          <!--  <div class="mdui-list-item-content">设备</div>-->
          <!--</li>-->
          
          <!--<li class="mdui-list-item mdui-ripple menu_Selected_N" id="waishe" onclick=" Notiflix.Notify.Info('开发中,敬请期待~');">-->
          <!--  <i class="mdui-list-item-icon-fox mdui-icon material-icons">new_releases</i>-->
          <!--  <div class="mdui-list-item-content">活动</div>-->
          <!--</li>-->
          
          <li class="mdui-list-item mdui-ripple menu_Selected_N" id="menu_help" onclick="MenuButton('menu_help')">
            <i class="mdui-list-item-icon-fox mdui-icon material-icons">help</i>
            <div class="mdui-list-item-content">帮助</div>
          </li>
          <li class="mdui-list-item mdui-ripple menu_Selected_N" id="menu_settings" onclick="MenuButton('menu_settings')">
            <i class="mdui-list-item-icon-fox mdui-icon material-icons">settings</i>
            <div class="mdui-list-item-content">设置</div>
          </li>
        </ul>
    </div>
    
    
    <!-- 花活 -->
    <style_ys>
        <iframe  src=" " id="globeweb" style="

    width: 1200PX;
    height: 900px;
    position: absolute;
    right: -500px;
    top: -300;
    border: 0px;

"></iframe>
    </style_ys>
    <!-- 游戏，服务器 配置 -->
    <game_config >
        <div class="container game_config_box">
            <div style="font-size: 24px;margin: 16px;"> <start_info>启动游戏</start_info></div>
            
            <div style="font-size: 14px;margin: 0px 16px;" id="game_config_name"> 游戏名</div>
            <!-- 关闭 -->
            <a href="javascript:;" class="mdui-btn mdui-btn-icon" style="position: absolute;top: 12px;right: 12px;" onclick="game_config_close()" id="close_bottom">
              <i class="mdui-icon material-icons">close</i>
            </a>
            <hr style="margin: 12px;">
            
            <img class="game_config_img" src="/up_img/load.png">
            
            <div class="game_config_set">
                <p style="margin-top: 1px;">
                        <i class="mdui-icon material-icons">slow_motion_video</i>&nbsp;负载 <online_connect>获取中</online_connect> %
                        &nbsp;&nbsp;&nbsp;
                        <i class="mdui-icon material-icons">network_check</i>&nbsp;延迟 <online_connect_ping>获取中</online_connect_ping> ms
                </p>
                    
                    
                
                <div id="server_ping_main" style="width: 100%;height: 180px;background: #7e7e7e99; float: left;">
                    <iframe frameborder="no" border="0" marginwidth="0" marginheight="0" width=350px height=100% id="ping_iframe" src=""></iframe>
                </div>
                
                
                <server>
                    <!--服务器位置-->
                    <get_server_sort style="float: left;">
                        <select class="mdui-select" mdui-select="{position: 'top'}" style="margin: 12px;max-width: 120px;" id="server_sort">
                          <option>加载失败,请重试</option>
                        </select>
                    </get_server_sort>
                    <!--服务器节点-->
                    <get_server_list style="float: left;">
                        <select class="mdui-select" mdui-select="{position: 'top'}" style="margin: 12px;max-width: 160;" id="server_list">
                          <option value="1">加载失败,请重试</option>
                        </select>
                    </get_server_list>
                </server>
                
                
                <center>
                    <!-- <label class="mdui-switch">
                      <input type="checkbox" checked/>
                      <i class="mdui-switch-icon"></i>
                       &nbsp;&nbsp;&nbsp;自动选择低延迟服务器
                    </label> -->

                   

                </center>
                
            </div>
            <hr style="margin: 12px 0px;margin-top: 0px;margin-bottom: 20px;">
            <center>
                <button class="mdui-btn mdui-btn-dense mdui-color-theme-accent mdui-ripple" id="conne_server_config_load" ><div class="mdui-spinner mdui-spinner-colorful"></div></button>
                <button class="mdui-btn mdui-btn-dense mdui-color-theme-accent mdui-ripple" onclick="conne_server_config()" id="conne_server_config_load_ok">启动加速</button>
            </center>
        </div>
    </game_config>
    
    <!--在线更新-->
    <update style="display: none;">
        <div class="container game_config_box" style="width: 100%;height: 100%;position: fixed;background-color: rgb(0 0 0 / 86%);">
            <div style="font-size: 48px;margin: 84px;margin-bottom: 0px;">需要更新</div>
            
            <div style="font-size: 20px;margin: 84px;margin-bottom: 0px;height: 300px;">正在更新,可能需要重启数次!<br><br>期间无需任何的操作,更新是自动的<br><br><br><br>如果不能自动更新或者报错,请关闭软件手动运行update.exe来进行更新<br><br>如果长期不能更新,也可能是update.exe文件被删除</div>
            
            
            
            <div style="font-size: 20px;margin: 0px 84px;">
                <div class="mdui-progress" id="update_indeterminate">
                  <div class="mdui-progress-indeterminate"></div>
                </div>

                
            </div>
            
        </div>
    </update>
    
    <rightbox style="position: absolute;top: 64px;left: 240px;width: calc(100% - 240px);overflow-x: hidden;overflow-y: hidden;">
        
        
        <!-- 游戏列表 -->
        <game class="rightbox_data">
            <div class="mdui-card" style="height: 50px;background-image: linear-gradient(90deg, #008bff5c 0%, #ffffff00 100%);">
                <h3 style="margin: 16px;">寻找你想加速的游戏</h3>
            </div>
            
            <div style="
    width: 300px;
    position: absolute;
    top: 8px;
    left: 200px;
">
                <div class="mdui-textfield mdui-textfield-expandable">
                  <button class="mdui-textfield-icon mdui-btn mdui-btn-icon" id="searchtip">
                    <i class="mdui-icon material-icons" style="color: white;">search</i>
                  </button>
                  <input class="mdui-textfield-input" id="user_ss" type="text" placeholder="搜索你想玩的游戏"/>
                  <button class="mdui-textfield-close mdui-btn mdui-btn-icon">
                    <i class="mdui-icon material-icons" onclick="get_all_game();">close</i>
                  </button>
                </div>
            </div>
            
            <list>
                
                
                
                <div class="mdui-row" style="width: 100%;margin: 0px;padding-top: 36px;" id="all_game_list">
                    <!-- 游戏配置 -->

                    
                    <?
                    for ($i=1; $i<=32; $i++)
                    {
                    ?>
                    <div class="mdui-col-sm-4 mdui-col-md-3 mdui-col-lg-2" style="padding: 0px;">
                        <div class="game_box hvr-grow-shadow">
                            <img class="game_img_a" src="/up_img/load.png">
                            <div class="gamename_text_back">
                                <div class="gamename_text">
                                    <span>gamename</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <?
                    }
                    ?>
                    
                    
                </div>

                
            </list>
        </game>
        
        
        
               <!-- 游戏列表_历史 -->
        <game_history class="rightbox_data">
            <div class="mdui-card" style="height: 50px;background-image: linear-gradient(90deg, #008bff5c 0%, #ffffff00 100%);">
                <h3 style="margin: 16px;">历史游玩游戏 ！</h3>
            </div>
            
            <list>
                
                
                
                <div class="mdui-row" style="width: 100%;margin: 0px;padding-top: 36px;" id="all_game_history_list">
                    <!-- 游戏配置 -->

                    
                    <?
                    for ($i=1; $i<=12; $i++)
                    {
                    ?>
                    <div class="mdui-col-sm-4 mdui-col-md-3 mdui-col-lg-2" style="padding: 0px;">
                        <div class="game_box hvr-grow-shadow">
                            <img class="game_img_a" src="/up_img/load.png">
                            <div class="gamename_text_back">
                                <div class="gamename_text">
                                    <span>gamename</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <?
                    }
                    ?>
                    
                    
                </div>

                
            </list>
        </game_history>
        
        <!--仪表盘-->
        <quilt class="rightbox_data">
            <h1 style="margin: 24px;"><gamename> 游戏名字</gamename></h1>
            <h3 style="margin:0px 24px;margin-bottom: 12px;">当前服务器负载 <online_connect_start>获取中</online_connect_start> % </h3>
            <h3 style="margin:0px 24px;">已加速 <connect_time>00:00:00</connect_time> </h3>
            <div style="padding: 24px;padding-top: 80px;">
                
                <div style="width: 600px;background: #2c2c2c63;border-radius: 8px;">
                    <img style="width: 180px;border-radius: 8px;background: #0e0e0e;" id="start_game_img" src="/up_img/load.png">
                    
                    
                    <div style="width: 420px;float: right;min-height: 32px;">
                        <div style="width: 128px;min-height: 128px;background: #3030308c;position: relative;top: 16px;left: 16px;border-radius: 12px;float: left;">
                            <div style="font-size: 40px;text-align: center;padding: 20px;">
                                <ping>0</ping> 
                            </div>
                            <p style="text-align: center;">即时延迟</p>
                        </div>
                        
                        <div style="width: 240px;float: right;min-height: 32px;background: #3030308c;border-radius: 12px;margin: 16px 18px;margin-bottom: 0px;">
                            <p style="margin-left: 12px;">已连接 : <server_name>XXXX服务器</server_name></p>
                        </div>
                        
                        <div style="width: 110px;float: right;min-height: 32px;background: #3030308c;border-radius: 12px;margin: 16px 18px;margin-bottom: 0px;height: 70px;">
                            <div style="font-size: 20px;text-align: center;padding: 8px;">
                                <flow style="white-space: nowrap;">---</flow>
                            </div>
                            <p style="text-align: center;margin-top: 0;">消耗流量</p>
                        </div>
                        
                        <div style="width: 110px;float: right;min-height: 32px;background: #3030308c;border-radius: 12px;margin: 16px 18px;margin-bottom: 0px;height: 70px;margin-right: 0;">
                            <div style="font-size: 20px;text-align: center;padding: 8px;">
                                <speed style="white-space: nowrap;">---</speed>
                            </div>
                            <p style="text-align: center;margin-top: 0;">当前速度</p>
                        </div>
                        
                        
                        <div style="width: 100%;height: 64px;margin-top: 170px;">
                            
                            <div style="width: 120px;float: left;min-height: 31px;background: #780e0e96;border-radius: 12px;margin-left: 140px;margin-top: 16px;" onclick="location.reload();">
                                <p style="text-align: center;">停止加速</p>
                            </div>
                        </div>
                        
                        
                        
                    </div>
                    
                    
                    
                    
                    
                </div>
                
            <div style="width: 600px;background: #2c2c2c63;border-radius: 8px;margin-top: 12px;">
                <p style="padding: 12;">先加速再运行游戏才有效果,如果没有效果看看是不是开着游戏加速的,而且请观察有没有跑流量(几KB不算),如果没跑流量也是没加速上</p>
            </div>
            </div>
            
            
            
        </quilt>
        
        <!--设置-->
        <Setup  class="rightbox_data">
            
            <div class="mdui-row">
                <div style="width: 220px;padding-left: 12px;float: left;">
                    
                    <div class="userbox">
                        <div class="avater_box">
                            <img src="src/img/test00001.jpg" style="width: 100%;border-radius: 128px;">
                        </div>
                        <img src="/ui/src/img/avater_box/b72dbf785e810e94fce2481265e71b6f16c64682.png" style="width: 200px;position: absolute;top: 14px;left: 14px;">
                        
                        <div class="user_data_box">
                            <h2>Speed Fox</h2>
                            
                            <!--<img src="/ui/src/img/ic_lv0.png" style="height: 16px;">-->
                            <!--<h5><yingbi>0</yingbi></h5>-->
                            <h5>硬币 : <yingbi>0</yingbi></h5>
                        </div>
                        
                    
                    </div>
                    <div class="userbox" style="padding: 12px;">
                        <p style="margin: 0;">框架版本:<SpeedFox_App_Version>无法获取</SpeedFox_App_Version></p>
                    </div>
                    <a href="http://ru.file.jihujiasuqi.com//web/obsidian-master/index.php" target="_blank" style="text-decoration: none;">
                    <div class="userbox" style="padding: 12px;"><p style="margin: 0;color: white;">点击进行框架性能测试</p></div>
                    </a>
                    <a href="http://ru.file.jihujiasuqi.com//web/fuck-2020-main_2//index.php" target="_blank" style="text-decoration: none;">
                    <div class="userbox" style="padding: 12px;"><p style="margin: 0;color: white;">点击进行框架显卡测试</p></div>
                    </a>
                    
                </div>
                
                <div class="setbox" onclick=" Notiflix.Notify.Info('还在开发中,功能暂不可用,敬请期待~');">
                    <div class="userbox" style="padding: 0px;max-width: 1000px;">
                        <div style="margin: 0;color: white;">
                            <div class="mdui-tab" mdui-tab >
                                <!--<a href="#example1-tab2" class="mdui-ripple">调试选项卡</a>-->
                                
                                
                              <a href="#example1-tab1" class="mdui-ripple">档案设置</a>
                              <a href="#example1-tab3" class="mdui-ripple">个性化设置</a>
                              <a href="#example1-tab2" class="mdui-ripple">配置设置</a>
                              <a href="#example1-tab4" class="mdui-ripple">兑换码</a>
                              <a href="#example1-tab0" class="mdui-ripple">debug</a>
                            </div>
                            
                            <!--选项卡-->
                            <div id="example1-tab1" class="mdui-p-a-2">
                                <p style="margin: 0;">个人信息 (功能开发中)</p>
                                <div>
                                    <div class="mdui-textfield">
                                      <i class="mdui-icon material-icons">account_circle</i>
                                      <label class="mdui-textfield-label">昵称</label>
                                      <input class="mdui-textfield-input" type="text"/>
                                      <div class="mdui-textfield-helper">注：修改一次昵称需要消耗6个硬币</div>
                                    </div>
                                    <div class="mdui-textfield">
                                      <i class="mdui-icon material-icons">border_color</i>
                                      <label class="mdui-textfield-label">个性签名</label>
                                      <textarea class="mdui-textfield-input" rows="4" placeholder="设置你的签名是😘"></textarea>
                                      <!--<div class="mdui-textfield-helper">Helper Text</div></div>-->
                                    </div>
                                    
                                    
                                    <div class="mdui-textfield">
                                      <i class="mdui-icon material-icons">people</i>
                                      <label class="mdui-textfield-label">性别</label>
                                            <div style="margin: 6px;margin-left: 55px;">
                                            <label class="mdui-radio">
                                            <input type="radio" name="group1"/>
                                              <i class="mdui-radio-icon"></i>
                                              男
                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </label>
                                            <label class="mdui-radio">
                                            <input type="radio" name="group1"/>
                                              <i class="mdui-radio-icon"></i>
                                              女
                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </label>
                                            <label class="mdui-radio">
                                            <input type="radio" name="group1"/>
                                              <i class="mdui-radio-icon"></i>
                                              其他
                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </label>
                                            <label class="mdui-radio">
                                              <input type="radio" name="group1" checked/>
                                              <i class="mdui-radio-icon"></i>
                                              武装直升机
                                            </label>
                                            </div>
                                    </div>
                                    <div class="mdui-textfield">
                                      <i class="mdui-icon material-icons">cake</i>
                                      <label class="mdui-textfield-label">生日</label>
                                      <input class="mdui-textfield-input" type="text" placeholder="yyyy-mm-dd"/>
                                      <div class="mdui-textfield-helper">生日当天可免费来线下实体店举办生日会！ </div>
                                    </div>
                                    
                                </div>
                            </div>
                            
                            <!--选项卡-->
                            <div id="example1-tab2" class="mdui-p-a-2">
                                <p style="margin: 0;">配置设置(功能开发中)</p>
                                <br><br>
                                
                                <div class="mdui-row" style="margin-left: 16px;">
                                  <div class="mdui-col-xs-5">显示右侧地球</div>
                                  <div class="mdui-col-xs-6">
                                      <label class="mdui-switch">
                                      <input type="checkbox" checked/>
                                      <i class="mdui-switch-icon"></i>
                                      </label>
                                  </div>
                                </div>
                                
                                <div class="mdui-row" style="margin-left: 16px;">
                                  <div class="mdui-col-xs-5">展示 Speed Fox 给您的广告推送</div>
                                  <div class="mdui-col-xs-6">
                                      <label class="mdui-switch">
                                      <input type="checkbox" checked disabled />
                                      <i class="mdui-switch-icon"></i>
                                      </label>
                                  </div>
                                </div>
                                
                                
                                <div class="mdui-row" style="margin-left: 16px;">
                                  <div class="mdui-col-xs-5">每次启动自动历史游戏页面</div>
                                  <div class="mdui-col-xs-6">
                                      <label class="mdui-switch">
                                      <input type="checkbox" checked_no/>
                                      <i class="mdui-switch-icon"></i>
                                      </label>
                                  </div>
                                </div>
                                
                                
                                <div class="mdui-row" style="margin-left: 16px;">
                                  <div class="mdui-col-xs-5">开机自动启动Speed Fox</div>
                                  <div class="mdui-col-xs-6">
                                      <label class="mdui-switch">
                                      <input type="checkbox" checked_no/>
                                      <i class="mdui-switch-icon"></i>
                                      </label>
                                  </div>
                                </div>
                                
                                <div class="mdui-row" style="margin-left: 16px;">
                                  <div class="mdui-col-xs-5">不使用 GPU 渲染 UI 页面</div>
                                  <div class="mdui-col-xs-6">
                                      <label class="mdui-switch">
                                      <input type="checkbox" checked_no/>
                                      <i class="mdui-switch-icon"></i>
                                      </label>
                                  </div>
                                </div>
                                
                                <div class="mdui-row" style="margin-left: 16px;">
                                  <div class="mdui-col-xs-5">自定义软件背景</div>
                                  <div class="mdui-col-xs-6">
                                      <label class="mdui-switch">
                                      <input type="checkbox" checked_no disabled/>
                                      <i class="mdui-switch-icon"></i>
                                      </label>
                                  </div>
                                </div>
                                
                                <br><br>
                                <div class="mdui-row" style="margin-left: 16px;">
                                    <button class="mdui-btn mdui-color-theme-accent mdui-ripple" onclick="outlogin()" style="background-color: #fe5353!important;">退出登录</button>
                                </div>
                                
                                
                            </div>
                            
                            <!--选项卡-->
                            <div id="example1-tab3" class="mdui-p-a-2">个性化设置</div>
                            
                            <!--选项卡-->
                            <div id="example1-tab4" class="mdui-p-a-2">
                                <p style="margin: 0;">请输入兑换码 (功能开发中)</p>
                                <div class="mdui-textfield">
                                  <i class="mdui-icon material-icons">local_play</i>
                                  <label class="mdui-textfield-label">请输入兑换码</label>
                                  <input class="mdui-textfield-input" type="text"/>
                                  <div class="mdui-textfield-helper">不要说看到兑换码就说是要付费,有没有一种可能,这个兑换码是换东西用的</div>
                                </div>
                                <div class="mdui-row" style="margin-left: 16px;">
                                    <button class="mdui-btn mdui-color-theme-accent mdui-ripple" onclick=" ()" style="background-color: #00aeecc7!important;margin: 12px 0px;margin-top: 32px;">确认兑换</button>
                                </div>
                                    
                            </div>
                            
                            <!--选项卡-->
                            <div id="example1-tab0" class="mdui-p-a-2">
                                调试    <br>
                                <button class="mdui-btn mdui-color-theme-accent mdui-ripple" onclick="location.reload();">刷新页面</button>
                                <a href="notification.php?title=%E6%9C%8D%E5%8A%A1%E5%99%A8%E6%AD%A3%E5%9C%A8%E7%BB%B4%E6%8A%A4%20!&data=%E5%A4%A7%E7%BE%A4:439084824%3Cbr%3E%E4%BA%8C%E7%BE%A4:755584144%3Cbr%3E%E4%B8%89%E7%BE%A4:133837493%3Cbr%3E&bottom=重新尝试"   style="text-decoration: none;">
                                    <button class="mdui-btn mdui-color-theme-accent mdui-ripple" >进入维护页</button>
                                </a>
                                
                                
                                <button class="mdui-btn mdui-color-theme-accent mdui-ripple" onclick="$.download_XMLHttpRequest('http://ru.file.jihujiasuqi.com//update/202212251730_autozip.exe', '极狐游戏加速器.exe', "", 'GET');">测试下载</button>
                                
                            </div>
                        </div>
                    </div>
                    
                    
                    
                </div>
            
            </div>
            
        </Setup>
    </rightbox>
    
</body>



<script src="src/mdui/js/mdui.min.js"></script>
<script src="src/js/jquery.js"></script>
<script src="src/js/notiflix-aio-2.7.0.min.js?1233"></script>
<script src="src/js/lazyload.js"></script>
<script src="src/js/jquery.base64.js"></script>

<script src="src/js/configApp.js?<?echo time()?>"></script>
<script src="src/js/sys.js?<?echo time()?>"></script>
