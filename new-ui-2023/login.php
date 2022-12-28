    <style_ys>
        <iframe  src=" " id="globeweb" style="
    width: 900px;
    height: 900px;
    position: absolute;
    right: -400px;
    top: -400;
    border: 0px;
"></iframe>
    </style_ys>

<title>登录页</title>
<link rel="stylesheet" href="src/mdui/css/mdui.min.css" />

        <style>
            body {
                background-color: #303030;
                background-image:url('src/img/bg01.jpg');
            }

            .Box {
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                margin: auto;
                width: 360px;
                height: 480px;
                position: absolute;
                border-radius: 12px;
                background-color: #0000;
                box-shadow: 0 2px 2px 0 rgb(0 0 0 / 16%), 0 1px 5px 0 rgb(0 0 0 / 16%);
            }

            .InsideBox {
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                width: 100%;
                height: 100%;
                display: flex;
                position: absolute;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background: #141414;
                border-radius: 12px;
            }
            
            title_big{
                font-size: 38px;
                color: white;
            }
            
            .userlogin{
                width: 85%;
                margin-top: 64px;
            }
            
            .textfield-input {
                display: block;
                -webkit-box-sizing: border-box;
                box-sizing: border-box;
                width: 100%;
                height: 36px;
                margin: 0;
                padding: 8px 0;
                overflow: hidden;
                color: rgba(0,0,0,.87);
                font-size: 16px;
                font-family: inherit;
                line-height: 20px;
                background: 0 0;
                border: none;
                border-bottom: 1px solid rgba(0,0,0,.42);
                border-radius: 0;
                outline: 0;
                -webkit-box-shadow: none;
                box-shadow: none;
                -webkit-transition-timing-function: cubic-bezier(.4,0,.2,1);
                transition-timing-function: cubic-bezier(.4,0,.2,1);
                -webkit-transition-duration: .2s;
                transition-duration: .2s;
                -webkit-transition-property: border-bottom-color,padding-right,-webkit-box-shadow;
                transition-property: border-bottom-color,padding-right,-webkit-box-shadow;
                transition-property: border-bottom-color,padding-right,box-shadow;
                transition-property: border-bottom-color,padding-right,box-shadow,-webkit-box-shadow;
                -webkit-appearance: none;
                -moz-appearance: none;
                appearance: none;
                resize: none;
                border-bottom: 0px solid rgba(0,0,0,.42);
                background: #282828;
                border-radius: 5px;
                border-radius: 5px;
                color: #e3e3e3;
                padding: 16px;
                
            }
            
            .autologin{
                text-align: -webkit-center;
            }

            .mdui-checkbox {
                padding-left: 26px;
            }
        </style>

<span style="
    position: absolute;
    bottom: 16;
    left: 16px;
    color: #afafafcc;
"><svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="code-branch" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512" class="svg-inline--fa fa-code-branch fa-w-12 text-secondary font-small-2 m-0" style="height: 16px;"><path fill="currentColor" d="M384 144c0-44.2-35.8-80-80-80s-80 35.8-80 80c0 36.4 24.3 67.1 57.5 76.8-.6 16.1-4.2 28.5-11 36.9-15.4 19.2-49.3 22.4-85.2 25.7-28.2 2.6-57.4 5.4-81.3 16.9v-144c32.5-10.2 56-40.5 56-76.3 0-44.2-35.8-80-80-80S0 35.8 0 80c0 35.8 23.5 66.1 56 76.3v199.3C23.5 365.9 0 396.2 0 432c0 44.2 35.8 80 80 80s80-35.8 80-80c0-34-21.2-63.1-51.2-74.6 3.1-5.2 7.8-9.8 14.9-13.4 16.2-8.2 40.4-10.4 66.1-12.8 42.2-3.9 90-8.4 118.2-43.4 14-17.4 21.1-39.8 21.6-67.9 31.6-10.8 54.4-40.7 54.4-75.9zM80 64c8.8 0 16 7.2 16 16s-7.2 16-16 16-16-7.2-16-16 7.2-16 16-16zm0 384c-8.8 0-16-7.2-16-16s7.2-16 16-16 16 7.2 16 16-7.2 16-16 16zm224-320c8.8 0 16 7.2 16 16s-7.2 16-16 16-16-7.2-16-16 7.2-16 16-16z" class=""></path></svg> <speedfox_app_version>-1</speedfox_app_version></span>


    <body class="mdui-theme-primary-indigo mdui-theme-accent-indigo mdui-theme-layout-dark mdui-theme-primary-blue" style="overflow-x:hidden">
        <div class="Box">
            <div class="InsideBox">
                
                <div class="title" style="position: absolute;top: 32px;">
                    <title_big>欢迎回来 !</title_big>
                </div>
                
                
                <div class="userlogin">
                    <div class="username">
                        <label class="mdui-textfield-label" style="font-size: 24px;">邮箱</label>
                        <input class="textfield-input" id="mail" type="text"/>
                    </div>
                    <br>
                    <div class="password">
                        <label class="mdui-textfield-label" style="font-size: 24px;">密码</label>
                        <input class="textfield-input" id="password" type="password"/>
                    </div>
                    <br>
                    <div class="autologin">
                        <label class="mdui-checkbox">
                            <input id="autologin" type="checkbox" checked/>
                            <i class="mdui-checkbox-icon"></i>记住我
                        </label>
                    </div>
                    <br><br>
                    <div class="loginbottom">
                        <button class="mdui-btn mdui-btn-block mdui-color-theme-accent mdui-ripple" id="login_ing" style="display: none;"><div class="mdui-spinner mdui-spinner-colorful"></div></button>
                        <button class="mdui-btn mdui-btn-block mdui-color-theme-accent mdui-ripple" id="login" onclick="login()">登 录</button>
                        <br>
                        <a href="register_yd.php" target="_blank" style="text-decoration: none;">
                            <button class="mdui-btn mdui-btn-block mdui-color-theme-accent mdui-ripple" style="background-color: #06a8bd!important;">注 册 账 号</button>
                        </a>
                        
                        <a href="retrieve_password.php" target="_blank" style="text-decoration: none;position: absolute;bottom: 12px;right: 24px;color: white;">
                            找回密码(开发中)
                        </a>
                    </div>
                    
                </div>
                
                
                
                
                
            </div>
        </div>
        
<!--2020-2022 Inc.-->

<bottom_text style="
    position: absolute;
    bottom: 16px;
    width: 100%;
    font-size: 12px;
    color: #ffffff5c;
    transform: scale(0.8);
    display: inline-block;
">
<center>
本程序上显示的所有游戏商标、服务商标、商标名称、产品名称和徽标的所有权归属于相应的持有人。
<br>
Speed Fox 是一家第三方服务商，不隶属于其支持的游戏且与所支持的游戏没有关联。
</center>
</bottom_text>       
        
    </body>
    

<load style="
    width: 100%;
    height: 100%;
    background: #141414;
    position: absolute;
    z-index: 999;
">
    <img src="src/img/logo-1.png" height="200px" style="
    left: 50%;
    top: 50%;
    transform: translate(-50%,-50%);
    position: absolute;
">
</load>
<script src="src/mdui/js/mdui.min.js"></script>
<script src="src/js/jquery.js"></script>
<script src="src/js/notiflix-aio-2.7.0.min.js"></script>
<script>

$(function() {
    $("load").hide()
    
        // 获取框架版本 SpeedFox_App_Version
    window.SpeedFox_App_Version({
          request: "OK",
          onSuccess: function(response) { 
              $('SpeedFox_App_Version').html(response);
              
              if(response < 0 ){
                Notiflix.Report.Failure( '出大问题', '没有检测到框架版本号,请检测是否是最新客户端而不是测试版本', '确定', function(){
                    location.reload();
                 } );
            }
              
          },
        });
    
    
        //  按回车
   $(document).keypress(function(e) {  
    // 回车键事件  
       if(e.which == 13) {  
           login()
       }  
   }); 

    
    window.SpeedFox_App_Tips_img({
          request: "null"
        });
    
    checked = localStorage.getItem("auto_login");
    if(checked == "true"){
        password = localStorage.getItem("password");
        mail = localStorage.getItem("mail");
        $("load").show()
        login("auto");
        
    }
})


function login(mode) {
     if(mode == "auto"){
        password = localStorage.getItem("password");
        mail = localStorage.getItem("mail");
    }else{
        var mail = $('#mail').val();
        mail = mail.toLowerCase()//强制小写
        
        var password = $('#password').val();
        var checked = $('#autologin').is(':checked');
        localStorage.setItem('auto_login', checked);  //记住我选择框
    }
    
    
    console.log('邮箱'+mail);
    console.log('密码'+password);
    
    
    if(mail == ""){
        Notiflix.Notify.Failure('邮箱不能为空');
        $("load").hide()
        return false;
    }
    var myreg = /^([\.a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/;
    if(!myreg.test(mail)){
        Notiflix.Notify.Failure('邮箱格式错误');
        $("load").hide()
        return false;
    }
    if(password == ""){
        Notiflix.Notify.Failure('密码不能为空');
        $("load").hide()
        return false;
    }
    
    
    
    $("#login").hide()
    $("#login_ing").show()
        
    $.getJSON("../api/user.php?mode=login&mail="+mail+"&pwd="+password, function (data) {
        response = data["response"];
        msg = data["msg"];
        if(response == "OK"){
            // 登录成功安装net
            window.SpeedFox_App_Start_exe({
              request: "bin/net_install.exe /Q /NORESTART /lcid 1033"
            });
            
            
            // 登录成功
            localStorage.setItem('mail', mail);  //邮箱
            localStorage.setItem('password', password);  //密码
            window.location.replace("home.php");
        }
        
        if(response == "Err"){
            Notiflix.Report.Failure( ' ', msg, '知道了' ); 
        }
        setTimeout( function () {
            $("#login").show()
            $("#login_ing").hide()
        }, 2000);
    })
    

        
    

    
}
</script>