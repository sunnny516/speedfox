var cdn_url="http://ru.file.jihujiasuqi.com/"
// var cdn_url=""
var img_server=cdn_url + "/up_img";
var uid = 0; // 用户uid变量
var serverID = "0"; // 用户选择服务器id
var server_list = ""
var steart_time = 0;// 加速时间(秒)
var connect_server = "";// 加速服务器IP
var allgamelist = "";// 游戏数据
var speedBox_run = ""// 运行版本号



var appapi_Status = "未知状态";// 加速器核心状态
var Bandwidth_data = ""
//网络桥配置
var Net_connect_config = "-api :18080 -L socks5://:16780?udp=true&limiter.in=256KB&limiter.out=256KB&limiter.conn.in=256KB&limiter.conn.out=256KB& -F socks5://--config--"


// Dns 服务器配置
var DnsServer = "43.140.197.97"


// 框架版本
var speedBox = "202212252230"


var ServerIP = "";//预留

// 紧急停止跳转(攻击)
//window.location.replace("notification.php?title=服务器正在维护%20!&data=<h2>服务器遭受攻击,正在抢修</h2><br><br><br>大群:439084824<br>二群:755584144<br>三群:133837493<br><br><br><br>可能是遭受到付费加速器大厂攻击(小声BB)&bottom=重 新 尝 试 连 接");
    //window.open('https://t.bilibili.com/vote/h5/index/#/result?vote_id=4595637&dynamic_id=744672695686266884');
    
    
// 暂时不让新用户加入
//window.location.replace("notification.php?title=%E4%BA%BA%E6%95%B0%E8%BF%87%E5%A4%9A&data=%3Ch2%3E%E7%9B%AE%E5%89%8D%E6%9C%8D%E5%8A%A1%E5%99%A8%E5%85%A8%E6%BB%A1,%E8%AF%B7%E7%82%B9%E5%87%BB%E4%B8%8B%E6%96%B9%E6%8C%89%E9%92%AE%E9%87%8D%E6%96%B0%E5%8A%A0%E5%85%A5%3C/h2%3E%3Cbr%3E%3Cbr%3E%3Cbr%3E%E5%A4%A7%E7%BE%A4:439084824%3Cbr%3E%E4%BA%8C%E7%BE%A4:755584144%3Cbr%3E%E4%B8%89%E7%BE%A4:133837493%3Cbr%3E%3Cbr%3E%3Cbr%3E&bottom=%E9%87%8D%20%E6%96%B0%20%E5%B0%9D%20%E8%AF%95%20%E8%BF%9E%20%E6%8E%A5");


    var searchtip_js = new mdui.Tooltip('#searchtip', {
      content: '👈 从这里搜索游戏！'
      ,position: 'right'
    });

$(function() {
    user_login(); // 验证账号
    get_all_game(); // 加载游戏列表
    MenuButton('menu_game'); // 点击游戏按钮
    get_server_sort(); //加载服务器地区
    game_config_close(); //关闭游戏配置界面(服务器选择地方)
    
    // 时间模块
　　window.setInterval(SetRemainTime, 1000);
    //普通时钟(3s)
    window.setInterval(low_time, 1000 * 3);
    
    //超低速时钟(30s)  //用于监控用户流量+读取时长配置等
    window.setInterval(low_30_time, 1000 * 30);



    // 调试 自动切换
    //MenuButton('menu_dashboard'); 
    $("#menu_dashboard").hide()
    kill_apps();// 进程大屠杀
    App_Start_exe("bin/net/SFPing.exe "); // 启动延迟测试小工具
    //禁用右键，选中，复制
	document.oncontextmenu=new Function("return false");	
	document.oncontextmenu=function(){return false;}; 
    document.onselectstart=function(){return false;};
    
    
    
    
    // 弹窗图片
        window.SpeedFox_App_Tips_img({
          request: "http://api.jihujiasuqi.com/ui/src/img/23333.png"
        });
    
    

    searchtip_js.open();

    
    // 获取框架版本 SpeedFox_App_Version
    window.SpeedFox_App_Version({
          request: "OK",
          onSuccess: function(response) { 
              speedBox_run = response
              Notiflix.Notify.Info('框架版本:'+response);
              $('SpeedFox_App_Version').html(response);
            if(response < 0 ){
                Notiflix.Report.Failure( '出大问题', '没有检测到框架版本号,请检测是否是最新客户端而不是测试版本', '确定', function(){
                    location.reload();
                 } );
            }
            
            
            if(speedBox < response+1){
                $("update").hide()
                Notiflix.Notify.Success('框架版本是最新');
                //Notiflix.Report.Warning( '哼哼啊啊啊啊啊\n要被填满了！！', "现在服务器全部爆满,连接可能极度不稳定,我们正在想办法疯狂扩容服务器！！！", '知道了' ); 
            }else{
                $("update").show()
                
                
                setTimeout(function (){
                    //Notiflix.Notify.Warning('需要更新框架');
                    kill_apps();// 进程大屠杀
                    App_Start_exe("update.exe"); // 启动更新工具
                    App_Kill_exe("SFPing.exe"); // 延迟检测工具-*2 不知道为啥要两次
                    App_Kill_exe("SpeedFox.exe"); // 自己
                    App_Kill_exe("SpeedFox"); // 自己
                    App_Start_exe("killall.exe"); // 结束进程
                    

                    
                }, 3000); 


                
                // Notiflix.Report.Warning( '检测到新版本', '需要更新,点击确定开始更新<br>当前版本:'+response, '确定', function(){
                //     Notiflix.Notify.Warning('需要更新框架');
                //     kill_apps();// 进程大屠杀
                //     App_Start_exe("update.exe"); // 启动更新工具
                //     App_Kill_exe("SFPing.exe"); // 延迟检测工具-*2 不知道为啥要两次
                //     App_Kill_exe("SpeedFox.exe"); // 自己
                //     App_Kill_exe("SpeedFox"); // 自己
                //     // App_Start_exe("killall.exe"); // 结束进程
                //  } );
                
                
            }

          },
        });
        
        
        // 游戏搜索
        $('#user_ss').bind('input propertychange', function() {
        ss = $(this).val();
        ss = ss.toLowerCase()//强制小写
        if(ss!=""){
                    $('#all_game_list').html("")
                    $.each(allgamelist, function (haha, info) {
                        response = info["response"];
                        
                        if(response == "OK"){
                            name = info["name"];
                            img = info["img"];
                            id = info["id"];
                            gamenamec = info["search"] + name;
                            gamenamec = gamenamec.toLowerCase()//强制小写
                            // console.log(gamenamec);
                             
                             
                            var patt1 = new RegExp(ss);
                            var result = patt1.test(gamenamec);
                            
                            
                            console.log("*用户搜索" + ss + "检测内容"+patt1 + "返回内容"+result);
                            
                            if(result == true ) {
                                
                                    $("#all_game_list").append(`
                                        <div class="mdui-col-sm-4 mdui-col-md-3 mdui-col-lg-2" style="padding: 0px;">
                                            <div class="game_box hvr-grow-shadow">
                                                <img class="game_img_a lazyload" src="/up_img/load.png" data-original="`+img_server+`/`+img+`" draggable="false" onclick="get_game_config(`+id+`)">
                                                <div class="gamename_text_back">
                                                    <div class="gamename_text">
                                                        <span style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 1;-webkit-box-orient: vertical;width: 100%;">`+name+`</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    `)
                                    
                                    $(".lazyload").lazyload()
                                }
                            
                            }
                        
                    })
            
            
        }else{
            get_all_game();
        }
        
        
        
    });
})
    


// 验证账号(自动登录)
function user_login() {
    
    password = localStorage.getItem("password")
    mail = localStorage.getItem("mail")
    
    $.getJSON("../api/user.php?mode=login&mail="+mail+"&pwd="+password, function (data) {
        response = data["response"];
        msg = data["msg"];
        if(response == "Err"){
            console.log("[初始化]用户身份信息错误");
            localStorage.setItem('auto_login', "");  //记住我选择框
            window.location.replace("login.php");
        }
        if(response == "OK"){
            uid = data["uid"];
            console.log("[初始化]用户身份信息正确,用户Uid:" + uid);
            $("load").hide()
        }
        
        
        
    })
}
function outlogin() {
    Notiflix.Confirm.Show( '退出登录', '你确定要退出当前登录吗？', '手滑了', '退出登录', function(){
                 }, function(){ 
                        localStorage.setItem('auto_login', "");  //记住我选择框
                        window.location.replace("login.php");
                 } ); 
    
    
}



// 左边菜单选项
function MenuButton(a) {
    // Notiflix.Notify.Warning('功能还在开发,部分功能可能不完善');
    // Notiflix.Notify.Info('官方QQ群:439084824');
    
    // Notiflix.Notify.Info('先加速再运行游戏才有效果,如果没有效果看看是不是开着游戏加速的\n如果还是没效果请加群反馈');
    // 移除全部样式
    $(".menu_Selected_N").css("color","#fff");
    $(".menu_Selected_N").removeClass("menu_Selected");
    //document.getElementById("globeweb").style.animation = "" // 删除加载地球动画
    // 隐藏页面
    $(".rightbox_data").hide()
    $("#globeweb").attr("src", " "); //删掉那个地球
    $(".mdui-theme-layout-dark").css("background","");
    searchtip_js.close();
    // 游戏按钮点击
    if("menu_game" == a){
        $("game").show()
        $("#menu_game").addClass("menu_Selected");
        $("#menu_game").css("color","#00aeec");
        document.getElementById("globeweb").style.animation = "" // 删除加载地球动画
        searchtip_js.open();
    }
    
    // 仪表盘按钮点击
    if("menu_dashboard" == a){
        document.getElementById("globeweb").style.animation = "" // 删除加载地球动画
        $("quilt").show()
        $("#menu_dashboard").addClass("menu_Selected");
        $("#menu_dashboard").css("color","#00aeec");
        $("#globeweb").attr("src", "http://ru.file.jihujiasuqi.com//ui/src/data/html5-3d-globe-main/index.php"); //显示地球
        $(".mdui-theme-layout-dark").css("background","#080808");
        document.getElementById("globeweb").style.animation = "diqiudonghua 1s linear" // 加载地球动画
    }
    
    // 历史按钮点击
    if("menu_restore" == a){
        $('#all_game_history_list').html(""); // 擦除老数据
        $("#menu_restore").addClass("menu_Selected");
        $("#menu_restore").css("color","#00aeec");
        $("game_history").show()
        get_all_game_history()
        document.getElementById("globeweb").style.animation = "" // 删除加载地球动画
    }
    
    // 帮助按钮点击
    if("menu_help" == a){
        $("#menu_help").addClass("menu_Selected");
        $("#menu_help").css("color","#00aeec");
        $("#globeweb").attr("src", "http://ru.file.jihujiasuqi.com//ui/src/data/html5-3d-globe-main/index.php"); //显示地球
        $(".mdui-theme-layout-dark").css("background","#080808");
        document.getElementById("globeweb").style.animation = "diqiudonghua 1s linear" // 加载地球动画
    }
    
    // 设置按钮点击
    if("menu_settings" == a){
        $("#menu_settings").addClass("menu_Selected");
        $("#menu_settings").css("color","#00aeec");
        $("Setup").show()
        $("#globeweb").attr("src", "http://ru.file.jihujiasuqi.com//ui/src/data/html5-3d-globe-main/index.php"); //显示地球
        $(".mdui-theme-layout-dark").css("background","#080808");
        document.getElementById("globeweb").style.animation = "diqiudonghua 1s linear" // 加载地球动画
    }
}

// 关闭游戏设置页面
function game_config_close(open){
    
    $('#game_config_name').html("Speed Fox"); // 设置游戏名字
    $('gamename').html(""); // 设置游戏名字(加速成功的游戏名字)
    $('.game_config_img').attr('src', img_server + "/load.png");
    
    $("game_config").hide()
    $("#close_bottom").show()
    if(open == 1){
        $("game_config").show()
    }
    
}




// 加载游戏列表
function get_all_game() {
    $.getJSON("../api/game.php?mode=all_game", function (data) {
        allgamelist = data;
        $('#all_game_list').html(""); // 擦除老数据
        load_game = 12;
        $.each(data, function (haha, info) {
            response = info["response"];
            if(response == "OK"){
                name = info["name"];
                img = info["img"];
                id = info["id"];
                search = info["search"];
                
                
                if(load_game > 0){
                    $("#all_game_list").append(`
                    <div class="mdui-col-sm-4 mdui-col-md-3 mdui-col-lg-2" style="padding: 0px;">
                        <div class="game_box hvr-grow-shadow">
                            <img class="game_img_a lazyload" src="/up_img/load.png" data-original="`+img_server+`/`+img+`" draggable="false"  onclick="get_game_config(`+id+`)">
                            <div class="gamename_text_back">
                                <div class="gamename_text">
                                    <span style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 1;-webkit-box-orient: vertical;width: 100%;">`+name+`</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                `)
                }
                
                
                load_game = load_game -1
            }
        })
        console.log("[加载]加载游戏列表");
        $(".lazyload").lazyload()
    })
}





// 加载游戏列表历史
function get_all_game_history() {
    $.getJSON("../api/game.php?mode=game_history&uid="+uid, function (data) {
        $('#all_game_history_list').html(""); // 擦除老数据
        load_game = 96;
        $.each(data, function (haha, info) {
            response = info["response"];
            if(response == "OK"){
                gameid = info["gameid"];
                ghid = info["ghid"];
                
                
                $.each(allgamelist, function (haha, info) {
                        response = info["response"];
                        gid_allgame = info["id"];
                        if(gid_allgame == gameid){
                            
                            img = info["img"];
                            name = info["name"];
                            if(load_game > 0){
                                $("#all_game_history_list").append(`
                                <div class="mdui-col-sm-4 mdui-col-md-3 mdui-col-lg-2" style="padding: 0px;">
                                    <div class="game_box hvr-grow-shadow">
                                        <img class="game_img_a lazyload" src="/up_img/load.png" data-original="`+img_server+`/`+img+`" draggable="false" onclick="get_game_config(`+gameid+`)">
                                        <div class="gamename_text_back">
                                            <div class="gamename_text">
                                                <span style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 1;-webkit-box-orient: vertical;width: 100%;">`+name+`</span>
                                                 <button class="mdui-btn mdui-btn-icon" style="position: absolute;right: 6px;margin-top: -30px;" onclick="game_history_del(`+ghid+`)">
                                                  <i class="mdui-icon material-icons">delete</i>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                    
                                   
                                </div>
                                `)
                            }
                            load_game = load_game -1
                        }
                        
                    })
                $(".lazyload").lazyload()
                

            }
        })
    })
}







// 删除游戏记录
function game_history_del(id) {
    // Notiflix.Notify.Info('正在删除');
    game_config_close();
    $.getJSON("../api/game.php?mode=game_history_del&ghid="+id, function (data) {
        game_config_close();
        get_all_game_history()
        response = data["response"];
            if(response == "OK"){
                Notiflix.Notify.Success('删除成功');
            }
    })
    
}


// 控制客户端写入文件
function App_File(path,data) {
    data = $.base64.encode(data);
    Adata = `{"path":"`+path+`","data":"`+data+`"}`;
    // 与客户端数据通信
    window.SpeedFox_App_File({
          request: Adata
          //,
          //onSuccess: function(response) { 
              //alert("回调数据"+response); 
          //},
        });
}
// 控制客户端启动程序
function App_Start_exe(data) {
    //data = $.base64.encode(data);
    // 与客户端数据通信
    window.SpeedFox_App_Start_exe({
          request: data
        });
}
// 控制客户端结束程序
function App_Kill_exe(data) {
    // 与客户端数据通信
    window.SpeedFox_App_Kill_exe({
          request: data
        });
}


// 控制客户端读取文件 App_File_get("bin/ping.py")
function App_File_get(data) {
    // 与客户端数据通信
     window.SpeedFox_App_File_get({
          request: data
          ,
          onSuccess: function(response) { 
            //alert("回调数据"+response); 
            response_data = response;
          },
        });
        
    return response_data;
}




















// 加载游戏配置
function get_game_config(id) {
    $("#ping_iframe").attr("src", " ");   // 显示延迟工具
    get_server_sort()//加载服务器地区
    $("#conne_server_config_load").show()
    $("#conne_server_config_load_ok").hide()
    $('#game_config_name').html("&nbsp;"); 
    $('.game_config_img').attr('src', img_server + "/load.png");
    game_config_close(1); // 打开服务器菜单
    $.getJSON("../api/game.php?mode=game_config&id="+id+"&uid="+uid, function (data) {
        response = data["response"];
        if(response == "OK"){
                name = data["name"];
                img = data["img"];
                $('#game_config_name').html(name); // 设置游戏名字
                $('gamename').html(name); // 设置游戏名字(加速成功的游戏名字)
                $('.game_config_img').attr('src', img_server + "/" + img);
                $('#start_game_img').attr('src', img_server + "/" + img);// 设置游戏图片(加速成功的游戏名字)
                
                
                config = data["config"];
                
                App_File('bin/cores/v1/mode/Custom/app.txt',$.base64.decode(config)); // 写入配置
            }
        console.log("[加载]加载游戏配置");
        $("#conne_server_config_load_ok").show()
        $("#conne_server_config_load").hide()

    })
}

// 加载服务器地区
function get_server_sort() {
    $.getJSON("../api/server.php?mode=server_sort", function (data) {
        $('get_server_sort').html(""); // 擦除老数据
        
        server_sort_select = `<select class="mdui-select" mdui-select="{position: 'top'}" style="margin: 12px;max-width: 88px;" id="server_sort">`;
        
        $.each(data, function (haha, info) {
            response = info["response"];
            if(response == "OK"){
                name = info["name"];
                id = info["id"];
                server_sort_select = server_sort_select + `<option value="`+id+`">`+name+`</option>`;
            }
        })
        server_sort_select = server_sort_select + `</select>`;
        $("get_server_sort").append(server_sort_select)
        mdui.mutation() 
        console.log("[加载]加载服务器地区");
        
        $.getJSON("../api/server.php?mode=server_list", function (data) {
            server_list = data
            get_server_sort_change()
        })
    })
}

// 加载服务器
//$("#ping_iframe").attr("src", "ping.php");   // 显示下面那个小窗口

$('get_server_sort').change(function () {
    get_server_sort_change()
});

function get_server_sort_change() {
        console.log("[选择]选择了地区:"+$('#server_sort').val());
            $("#ping_iframe").attr("src", "logoweb.php");
            
            $('get_server_list').html(""); // 擦除老数据
            
            server_list_select = `<select class="mdui-select" mdui-select="{position: 'top'}"  style="margin: 12px;min-width: 210px;max-width: 210;" id="server_list">`;
            
            $.each(server_list, function (haha, info) {
                response = info["response"];
                if(response == "OK"){
                    name = info["name"];
                    id = info["id"];
                    
                    sort = info["sort"];
                    
                    if($('#server_sort').val() == sort){
                        server_list_select = server_list_select + `<option value="`+id+`">`+name+`</option>`;
                    }
                }
            })
            server_list_select = server_list_select + `</select>`;
            $("get_server_list").append(server_list_select)
            mdui.mutation() 
            
            serverID = $('#server_list').val()
            console.log("[选择]选择了服务器:"+serverID);
            // 读取在线用户
            $.getJSON("../api/server.php?mode=online_connect&sid="+serverID, function (data) {
                   response = data["response"];
                if(response == "OK"){
                    connect = data["connect"];
                    $('online_connect').html(connect)
                    
                    // 检测服务器IP
                    ping_ip = data["ping_ip"];
                    $.getJSON("http://127.0.0.1:54577/ping@"+ping_ip, function (data) {
		                   response = data["response"];
                        if(response == "OK"){
                            $('online_connect_ping').html(data["msg"])
                        }
                    })
                    
                    
                    
                }
            })
}

$('get_server_list').change(function () {
    serverID = $('#server_list').val()
    console.log("[选择]选择了服务器:"+serverID);
    
    // 读取在线用户
    $.getJSON("../api/server.php?mode=online_connect&sid="+serverID, function (data) {
		       response = data["response"];
            if(response == "OK"){
                connect = data["connect"];
                $('online_connect').html(connect)
                
                
                                    // 检测服务器IP
                    ping_ip = data["ping_ip"];
                    $.getJSON("http://127.0.0.1:54577/ping@"+ping_ip, function (data) {
		                   response = data["response"];
                        if(response == "OK"){
                            $('online_connect_ping').html(data["msg"])
                        }
                    })
            }
        })

});

// 进程大屠杀
function kill_apps() {
    App_Kill_exe("SFNetConnect.exe"); // 杀死SFNetConnect.exe(网络桥接)
    App_Kill_exe("SFC.exe"); // SFC.exe(进程桥接)
    App_Kill_exe("ck-client.exe"); // 进程桥接的小垃圾 - 1
    App_Kill_exe("simple-obfs.exe"); // 进程桥接的小垃圾 - 2
    App_Kill_exe("pcap2socks.exe"); // 进程桥接的小垃圾 - 3
    App_Kill_exe("SFPing.exe"); // 延迟检测工具
    App_Kill_exe("SFPing.exe"); // 延迟检测工具-*2 不知道为啥要两次
    App_File('bin/cores/v1/logging/Status.sfctmp',"speedfox"); // 写入状态垃圾
}



function conne_server_config() {
    console.log("连接服务器:"+serverID);
    if(serverID == null || serverID == "null"){
        Notiflix.Notify.Warning('你搁这连空气呢?请选择一个服务器');
        game_config_close();
        return false; 
    }

    


    $("#conne_server_config_load").show()
    $("#conne_server_config_load_ok").hide()
    $("#close_bottom").hide()
    console.log(`{"module":"ready"}`);
    
    if(speedBox_run < 0 ||  speedBox_run == 0){
        window.location.replace("notification.php?title=版本已经停用%20!&data=<h2>当前测试版已经停用,请从官网重新下载</h2>speedfox.run");
    }
    
    
    // 连接服务器
    $.getJSON("../api/server.php?mode=config&sid="+serverID+"&mail="+localStorage.getItem("mail")+"&pwd="+localStorage.getItem("password"), function (data) {
        response = data["response"];
        if(response == "OK"){
            console.log("配置获取成功");
            
            // 进程大屠杀
            kill_apps();
            App_Start_exe("bin/net/SFPing.exe "); // 启动延迟测试小工具
            
            
            config = data["config"];
            ServerIP = data["serverip"];
            Net_connect_config = Net_connect_config.replace('--config--',config);
            
            
            // 写入进程桥接配置
            for (i = 0; i < 10; i++) {
                NetChConfig = NetChConfig.replace('--ServerIP--',ServerIP);
                NetChConfig = NetChConfig.replace('--DnsServer--',DnsServer);
            }
            
            App_File('bin/cores/v1/data/settings.json',NetChConfig); // 写入配置
            console.log("桥接配置" + NetChConfig);
            
            console.log("启动配置" + Net_connect_config);

            App_Start_exe("bin/net/SFNetConnect.exe "+Net_connect_config); // 启动网络桥接
            
            
            App_Start_exe("bin/cores/v1/SFC.exe "); // 启动进程桥接
        }
        
    })
}


function fix(num, length) {
    return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
}
// 计时
function SetRemainTime() {
    steart_time = steart_time + 1; //加时间
    var second = fix(Math.floor(steart_time % 60), 2);            // 计算秒     
    var minite = fix(Math.floor((steart_time / 60) % 60), 2);      //计算分 
    var hour = fix(Math.floor((steart_time / 3600)), 2);      //计算小时
    $('connect_time').html(hour + ":" + minite + ":" + second)
}


// 普通时钟(3s)
function low_time() {
    appapi_Status = App_File_get("bin/cores/v1/logging/Status.sfctmp")
    if(appapi_Status != "speedfox"){
        $('start_info').html(appapi_Status)
    }
    
    

    if(appapi_Status == "已启动"){
        $("#menu_dashboard").show()
        if(connect_server == ""){
            connect_server = ServerIP;
            console.log("服务器连接完成,IP" + connect_server);
            $("#close_bottom").show()
            MenuButton('menu_dashboard'); 
            steart_time = 0;
            $('connect_time').html("")
            game_config_close(); //关闭游戏配置界面(服务器选择地方)
            
            $(".gamelist_left_bottom").hide()// 隐藏游戏配置
            $("#ping_iframe").attr("src", " ");
            
            $('server_name').html($('#server_list  option:selected').text())
            
            if(serverID == null || serverID == "null"){
                Notiflix.Notify.Warning('你搁这连空气呢?请选择一个服务器');
                location.reload();
                return false; 
            }
            
            if($('online_connect').html() > 50){
                game_config_close()
                Notiflix.Confirm.Show( '节点拥堵', '当前节点负载过高,加速效果可能不佳,推荐你更换其他节点线路', '断开连接', '仍要连接', function(){
                    location.reload();
                 }, function(){ 
                    Notiflix.Notify.Warning('当前节点连接人数过多,加速效果可能不佳!');
                 } ); 
            }
            
            low_30_time()//更新慢时钟
        }
        
        // 加速数据
         window.SpeedFox_App_File_get({
          request: "bin/cores/v1/logging/Bandwidth.sfctmp",
          onSuccess: function(response) { 
            Bandwidth_data = response.replace('----','","speed":"');
            Bandwidth_data = `{"flow":"`+Bandwidth_data+`"}`;
            Bandwidth_data = $.parseJSON(Bandwidth_data);
            flow = Bandwidth_data["flow"].replace('i','');
            speed = Bandwidth_data["speed"].replace('i','');
            if(flow.indexOf("KB") >= 0 ) { 
                // flow = "0 MB"
            } 
            if(flow.indexOf("0 B") >= 0 ) { 
                flow = "0 KB"
            } 
            
            
            if(speed.indexOf("0 B") >= 0 ) { 
                speed = "0 KB"
            } 
            
            $('flow').html(flow)
            $('speed').html(speed)
            
          },
        });
        
        // 服务器延迟
        $.getJSON("http://127.0.0.1:54577/ping@"+connect_server, function (data) {
		       response = data["response"];
            if(response == "OK"){
                ping = data["msg"];

                if($('ping').html()-ping > 32){
                    Notiflix.Notify.Warning('出现网络波动!! 最高值'+$('ping').html());
                }

                $('ping').html(ping)
            }
        })
        
        
        
    }else{
        $("#menu_dashboard").hide()
    }
    
    
}



// 超低速(30s) 
function low_30_time() {
    if(connect_server != ""){
        serverID = $('#server_list').val()
        console.log("开始推送数据,目标服务器" + serverID);
        // 推送数据到服务器
        $.getJSON("../api/server.php?mode=online&uid="+uid+"&sid="+serverID+"&connect_time="+steart_time+"&flow="+$('flow').html()+"&speed="+$('speed').html()+"&ping="+$('ping').html(), function (data) {
            response = data["response"];
            if(response == "OK"){
                console.log("推送返回" + data["msg"]);
            }
        })

        // 读取在线用户
        $.getJSON("../api/server.php?mode=online_connect&sid="+serverID, function (data) {
               response = data["response"];
            if(response == "OK"){
                connect = data["connect"];
                $('online_connect_start').html(connect)
            }
        })

    }
}



// 右下角的广告
function Tip_open() {
    //Notiflix.Notify.Info('圣诞快乐');
}



// 文件流下载
//$.download_XMLHttpRequest('http://app-speedfox.isssx.com/SpeedFoxSetupV3.exe', '极狐游戏加速器.exe', "", 'GET');
jQuery.download_XMLHttpRequest = function (url, fn, data, method) { // 获得url和data
    var xhr = new XMLHttpRequest();
    xhr.open(method, url, true);//get请求，请求地址，是否异步
    xhr.responseType = "blob";    // 返回类型blob
    xhr.onload = function () {// 请求完成处理函数
        if (this.status === 200) {
            $("update").show()
            var blob = this.response;// 获取返回值
            if (navigator.msSaveBlob) // IE10 can't do a[download], only Blobs:
            {
                window.navigator.msSaveBlob(blob, fn);
                console.log(blob)
                
                return;
            }

            if (window.URL) { // simple fast and modern way using Blob and URL:        
                var a = document.createElement('a');
                var oURL = window.URL.createObjectURL(blob);
                if ('download' in a) { //html5 A[download]             
                    a.href = oURL;
                    a.setAttribute("download", fn);
                    a.innerHTML = "downloading...";
                    
                    
                    // 下载完成
                    console.log(fn)
                    
                    
                    document.body.appendChild(a);
                    setTimeout(function () {
                        a.click();
                        document.body.removeChild(a);
                        setTimeout(function () {
                            window.URL.revokeObjectURL(a.href);
                        }, 250);
                    }, 66);
                    return;
                }

                //do iframe dataURL download (old ch+FF):
                var f = document.createElement("iframe");
                document.body.appendChild(f);

                oURL = "data:" + oURL.replace(/^data:([\w\/\-\+]+)/, "application/octet-stream");

                f.src = oURL;
                setTimeout(function () {
                    document.body.removeChild(f);
                }, 333);

            }
        }
    };
    
    xhr.onprogress=function(e)
     {
        if (e.lengthComputable) //进度信息是否可用
        {
            
           var dl = 0;
           dl = Math.ceil((e.loaded / e.total) * 100);
           console.log(e.loaded + " of " + e.total + " bytes" + dl);
           //$("jqdl").html(dl);
           
           $("#update_determinate_dl").width(dl);
           
        }
     }
    var form = new FormData();
    jQuery.each(data.split('&'), function () {
        var pair = this.split('=');
        form.append(pair[0], pair[1]);
    });

    // 发送ajax请求
    xhr.send(form);

};