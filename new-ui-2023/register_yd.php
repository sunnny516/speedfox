
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>用户协议</title>
    <style>
            body {
            background-image: url(src/img/bg01.jpg);
        }
        .main {
            width: 900px;
            margin: 25px auto;
            background: #141414;
            border-radius: 12px;
            padding: 25px 55px;
            box-sizing: border-box;
            display: none;
        }

        .title_group h1 {
            font-size: 1.6em;
            text-align: center;
            margin-bottom: 0;
            color: #fff;
        }

        .title_group h3 {
            font-size: 1.1em;
            text-align: center;
            color: #777;
            font-weight: 400;
            margin-top: 8px;
            margin-bottom: 0;
        }
        .title_group h4{
            font-size: .8em;
            text-align: center;
            color: #777;
            margin-bottom: 25px;
            margin-top: 8px;
        }
        .conter_overflow{
            position: relative;
        }
        .conter_tips {
           font-size: 12px;
            color: #444;
            padding: 5px 30px;
            border: 1px solid #404040;
            overflow: auto;

        }

        .conter_tips .row {
            margin: 15px 0 5px 0;
            font-size: 15px;
        }

        .conter_tips .line {
            line-height: 19px;
            color: #666;
            font-size: 12.5px;
            margin-bottom: 3px;
        }
        .conter_tips .line-content{
            padding-left: 15px;
        }
        .select_ground {
            display: inline-block;
            cursor: pointer;
            margin-left: 10px;
            padding-top: 1px;
            height: 25px;
            line-height: 25px;
        }

        .conter_select {
            margin-top: 25px;
            padding-left: 10px;
            text-align: center;
            position: relative;
        }

        .select_ground span {
            mix-blend-mode: luminosity;
            display: inline-block;
            height: 22px;
            width: 22px;
            background-size: 30px;
            transition: all 300ms;
            background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAJYAAACWCAYAAAA8AXHiAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyhpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNi1jMTQ1IDc5LjE2MzQ5OSwgMjAxOC8wOC8xMy0xNjo0MDoyMiAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTkgKE1hY2ludG9zaCkiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6RERFQzQ4RkRDNjNGMTFFOTkxMzRGNjVBQjE0MEU5QUIiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6RERFQzQ4RkVDNjNGMTFFOTkxMzRGNjVBQjE0MEU5QUIiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDpEREVDNDhGQkM2M0YxMUU5OTEzNEY2NUFCMTQwRTlBQiIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDpEREVDNDhGQ0M2M0YxMUU5OTEzNEY2NUFCMTQwRTlBQiIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PkoEK4QAAAY9SURBVHja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');
            background-size: 22px;
            vertical-align: text-top;
        }

        .select_ground.pitch span {
            background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAJYAAACWCAYAAAA8AXHiAAAL5klEQVR4Xu2dfWxVZx3Hf79z2kJHGbDIrNL23i4TE6MLTKC9twxhiLwsDhMdL72XEY1/aJQ5F7cs0ZglGl/i5hga/cvMjXtLqTO6OBksYHHQHsrW6Ta3oJv03sKKhIHpaHm57T0/czsuMmg5z/Occ3refv33+f5enu/zuc95TQ8C/7EDLjiALuTklOwAMFgMgSsOMFiu2MpJGSxmwBUHGCxXbOWkDBYz4IoDDJYrtnJSBosZcMUB18GqzyaXaGjOBdIaEeAWIKoF5NscrqzmREkJiABOAGIfAB01Te1fxzZ1HXCzB8fBqu2YP3vKyNT1ALASAJYjYLWbE+Dcag4Q0TkE3EsAe0aLozvf2Xz4tFqm8aMcA6uuI1GtFeBBDfA7gDDdySY5l9sO0CAQ/ARGpmzNfXn/BSeqOQJWPNO8HkDbBgg3O9EU5/DGASI4AUDfyKeNP9jtwB5YHaDHC4lHAfF+u41wvH8cIIAf5Vu7vwcIpNqVMljxJ+fNhKrqZwFwiWpxjvOxA0S7h6sG7zm17s0hlS7VwOpcWhEbKLyIAAmVohwTFAdoT67VWK2ycymBFcsksojYGhR7uE91Bwjo8XzKeEA2gzRYsWzimwj4C9lCrA+wA0ituVZjh8wMpMD60LMt02vOmscB8UaZIqwNugN0smLWqdjba96+KDoTKbBi2eRjCCC9LYo2wzpfO/BwLtX9U9EOhcGak2mqq0T9mGhi1oXNARocqtHq313bdVZkZsJgxdqSDyDBYyJJr9EQbS0SdUKl9saxDd3/VsrBQbYcqNueuFVH+BQiLgWA+5SSSZxriYOVTf4FAZbJNEQABwkKm/tTLx+ViWOtuw7MaV80t3K04ilAaJapRASZfLp7k0iMEFg3ZZpunI76GQTQRZKWNAT0XP4tYy08AqZoDOsm0YFHQIvfmvgzIK4Sr0qDuZQxU0QvBFa8LfEFIBR+fkREp8+CecuZdM97Ik2wxhsHGrKLZ2lUzMlc5ZtQXNCf6um16lgIrIZM8xYNtW1WycrjBPSDfMr4vqiedd45IH2lT+aGXPrQTquOhcCKZZI/RITvWiW7DJZGLfmNRreonnXeORDPJlYC4G7RDgjowXzKeNRKLwhW4jeI+BWrZOVxxGJtX2vPSVE967xzoDGbjBFATrQDAvplPmVssdKLgZVNPoMAX7RKdnm8UFXt1AtjwjVZqORA6QXNihE8JxxMsDOX7t5gpWewrBwK+bgsWET0TD5t3GNlC4Nl5VDIxxmskC+wV9NjsLxyPuR1GayQL7BX02OwvHI+5HUZrJAvsFfTY7C8cj7kdRmskC+wV9NjsLxyPuR1GayQL7BX02OwvHI+5HUZrJAvsFfTY7C8cj7kdRmskC+wV9NjsLxyPuR1GayQL7Ds9D76p0/fMPD5XvEX9CYowGDJOh9WfefSivhAYRcQVeaqBlfCujcLdqbKYNlxLyyxZagAVoxNiWg/jExZbec1cAYrLHCozuNqqC7lIaJuHJmyXBUuBkt1QcIQNwFU5anZgYvBCgMgKnOwgMouXAyWyqIEPUYQKjtwMVhBh0S2f0moVOFisGQXJsh6RahU4GKwggyKTO82obp0G6LnvDm8/OS9rw1blWawrBwKw3jHJ6riIzOfg/J9KpU5EQlDVUrPYKmYHKSYElSFGXvg/X/lqPYnCRWDpWZzcKI8gorBCg4i8p16CBWDJb9cwYjwGCoGKxiYyHXpA6gYLLkl87/aJ1AxWP5HRbxDH0HFYIkvm7+VPoOKwfI3LmLd+RAqBkts6fyr8ilUDJZ/kbHuzMdQRRaseFtilUk02p86tNd6Bf2piGWT+xDgTuXuiHqGpmsrRD/nJlsncs8KY9mmZUj6rpJRhMU1+VRPp6xpXurjTy6dCpUXn5/sZ3+yc44UWA2Z5hYNtL2AMHXMKIILQYKrBBVVXtyHiEnZhS7rieiVC+bwEpFXX1RrROpQWJdNLNIJOhHxhg8YFhC4nILqLJjLJuPraZHYsWI7EvPBxBcRoGbcX6HP4QoaVJHYserbk5/Ui3QQAGdcd2v3KVxBhCr0YJWg0or0VwS8Seh8geCCCeZn+9OHuoT0LouCClWowWrc3vJxUzO7haG6BAkRnSOgz3kNV5ChCi1YtR3zZ08tVP8DEG5W2VRKcJmkrTq2qeuASrzdmA8/fdu0qXrNbgRYrJqLgHr1ysLyo+t6B1Vz2IkL7cl7PJN4HBDvVzXHq50r6DtV2e/QglWaYNDgCgtUoT0UXrlLBQWuMEEVCbCCsHOFDarIgOVnuMIIVaTA8iNcY1d/2rQX7D77m6zHNDIXQqE+eR/PCCfOuYoIy46njMMyRl+tLUFVrU3rBMSFqnlKD5T9CFXkdqzyAtqGC2CoCLRcFa6wQxVZsBw5LCrC5QRUQPT6e2Aunoy3FFR308gdCh29FSEJl1NQmah/pj918L+qiz4ZcZEGazJ3rihBFelD4ZW/2lg2+SsE+LrqL5ksdq6oQcVgXUGSW3BFESoG66otymm4ogoVgzXOsc8puEaKw2/YvU9VuvoLwon6eKcQkT95H/cmajb5BADcp3rOBQRnCegtRLzdRo5XR6vozuPrjDPKOTwMZLAmMN/uzmVrTQO8U5XnzWBdhwBP4AoBVHyOJbCtTCpcIYGKwRIAqySZFLhCBBWDJQiW63CFDCoGSwIs1+AKIVQMliRYjsMVUqgYLAWwHIMrxFAxWIpg2YeLjpigJ/3+6osNe/gjTXbMU7tapCMFLNwx0Nr7rp3afo/lG6Q2V0gOrmhAxYdCm1CVw8Xgig5UDJZDYFmfc0ULKgbLQbAmhit6UDFYDoN1LVzRhIrBcgGs/8NFy6Jw9TeRhXxV6BJcDdnFs8J8n8rKNgbLyiEeV3KAwVKyjYOsHGCwrBzicSUHGCwl2zjIygEGy8ohHldygMFSso2DrBxgsKwc4nElBxgsJds4yMoBBsvKIR5XcoDBUrKNg6wcYLCsHOJxJQcYLCXbOMjKAU/BimeS7YCw3qrJ8vj54lCN298yFu2Fddd3YOx/g+k1QxI+tedS3Rut9GglKI3HMsltiLBFRDum0czG3MZDOWE9Cz1zIPb0okbUK46KN0BP5FKG5dfahMCKZxIPA+KPRYubQOv6U8bvRPWs886BeDa5AQB2iHZASA/lW42fWemFwGrIJu7VAJ+ySlYeJ6Ln82ljjaiedd45EM8kSl/dWCraARGl8mmjzUovBFZ9JrlQR5D6dAhB8c58qqfTqgEe986BWKZ5NaK2S7KD+blU99+tYoTAunSeNYAIH7FKeHmc6D+omfP6WntOCsewcNIciHcsrIWRytcAYLZ4UcrnUkZcRC8MVjyT+DUgfk0k6RWHxL4iwNrjaeN1mTjWuutAXVvTbbqp/RERG6UqEW3NpY1vi8QIg9XQ1rRCI/0FkaTXaAgOENBvkUji6kOpEgddzwFdaySTvqr6eTwTi3f0t/YcFDFZGKyxw2E2+RICLBBJzJpwOUBE3fm00SI6KymwGjLNLRpqQsSKNsC6YDhAGt2e32j8TbRbKbBKSePZxG4AXClagHXBd4AAfp9PdX9JZibSYM3JNNVVov6K3NWETEus9ZMDRHR8tFic987mw6dl+pIGq5S8fkfLAt2k0iFxikwx1gbLASIaRg0W5FqNI7KdK4E1dkjMNK8H1NplC7I+OA4QFO/Kp3pkb6COTVAZrLGda3vz3bqmdfDOFRxYRDolonMEcHd/2tgnoh9PYwus93eupmZArXRCP0O1CY7zlQOn0Bxd0bfp8Kt2urINVqn4nPZFcytGK36OCHfZaYZjPXegvaCNPDSw8aVjdjtxBKxyE/XZ5BIdoPSpt3l2G+P4yXOAiLoIzW/1p3p6narqKFjlpkrPojQTVyFqq5BoMSBWOtUw57HvAAGdB4L9hLhbN3FP36auf9rP+sEMroB1dZN12aaPIemNukaNQFhr96LBaRMikI9MoBMApWe1o0f7Uy+7/sx2UsCKwMLxFK9ygMFiJFxxgMFyxVZOymAxA644wGC5YisnZbCYAVccYLBcsZWTMljMgCsOMFiu2MpJ/wccd+YtCJOs4QAAAABJRU5ErkJggg==');
        }

        .conter_select img {
            width: 30px;
            margin-right: 10px;
        }

        .conter_select>span {
            display: inline-block;
            height: 30px;
            line-height: 30px;
            color: #666;
            font-size: 17px;
            vertical-align: middle;
        }

        .conter_btns {
            text-align: center;
            padding: 20px 0;
        }
        .conter_btns .btn.disabled{
            background-color: #cbcbcb; 
            border-color: #cbcbcb;
            color: #fff;
        }
        .conter_btns .btn {
            border: none;
            font-size: 1.1em;
            padding: 0.5em 4.6em;
            background-color: #00bcd4;
            outline: none;
            color: #fff;
            cursor: pointer;
            transition: all 500ms;
            border-radius: 2px;
        }

        .conter_btns .btn:hover {
            background: #00bcd4;
        }
        .conter_shadow.shadow_top{
            background: -webkit-linear-gradient(bottom,rgba(255, 255, 255, 0),#03a9f438);
            top: 0;
        }
        .conter_shadow.shadow_bottom{
            background: -webkit-linear-gradient(top,rgba(255, 255, 255, 0),#03a9f438);
            bottom: 0;
        }
        .conter_shadow{
            position: absolute;

            height: 10px;
            width: 100%;
            left: 0;
        }
        .hide{
            display: none !important;
        }
        .show{
            display: block !important;
        }
        .select_tips{
            display: none;
            position: absolute;
            line-height: 22px;
            min-width: 12px;
            padding: 5px 10px;
            font-size: 12px;
            _float: left;
            border-radius: 2px;
            box-shadow: 1px 1px 3px rgba(0,0,0,.2);
            background-color: #000;
            color: #fff;
            left: 273px;
            top: -40px;
            background: red;
        }
        .select_tips:after{
            content: '';
            display: inline-block;
            width: 0;
            height: 0;
            border-right: 8px solid transparent;
            border-left: 8px solid transparent;
            border-top: 8px solid red;
            position: absolute;
            bottom: -8px;
            left: 10px;
        }
        .ubind_click{
            cursor: pointer;
        }
        .conter_read_tips{
                position: absolute;
    right: 15px;
    font-size: 12px;
    padding: 5px 10px;
    background: #bababa;
    color: #555;
        }
        .conter_read_tips.active{
            background: #00bcd4;
            color: #fff;
            border: none;
        }
        ::-webkit-scrollbar {
        	/*滚动条整体样式*/
        	width : 12px;  /*高宽分别对应横竖滚动条的尺寸*/
            height: 1px;
            padding: 2px;
        }
        ::-webkit-scrollbar-thumb{
        	/*滚动条里面小方块*/
        	border-radius: 1px;
        	box-shadow : inset 0 0 6px rgba(0, 0, 0, 0.1);
        	background   : #bbb;
        }
        ::-webkit-scrollbar-track{
            /*滚动条里面轨道*/
            border-radius: 1px;
        	box-shadow:inset 0 0 6px rgba(0, 0, 0, 0.1);
        	background:#ededed;
        }
    </style>
</head>

<body>
    <div class="main">
        <div class="title_group">
            <h1 class="title">欢迎您使用Speed Fox</h1>
            <h3 class="subhead_title">在使用之前,您需要阅读《使用说明》 和《用户协议》</h3>
            <h4>协议最近更新时间：2022年12月20日</h4>
        </div>
        <div class="conter_overflow">
            <div class="conter_shadow shadow_top hide"></div>
            <div class="conter_read_tips">已阅读<span>0%</span></div>
            <div class="conter_tips">
                <div class="content-box">
                    <h5 class="row">用户须知</h5>
                    <div class="line">
                        感谢您选择 SpeedFox 请在使用过程中遵守本协议。
                        在接受协议之前，请务必仔细阅读本协议的全部内容。如果您不同意本协议内容，请不要使用我们提供的服务。您的使用行为将视为对本协议的接受，并同意接受其中各项协议的约束。
                        SpeedFox 有权在任何时间及不需事先通知的情况下修改、取消、增加、替代任何在此列明的条款，而此条款均对 SpeedFox 的使用者及用户有效力及约束力。因此，您应定期浏览本页。
                        如在本条款作出修订后仍继续使用 SpeedFox 即被视为接受这些修订。
                    </div>
                </div>
                <div class="content-box">
                    <h5 class="row">一、服务内容与对象</h5>
                    <div class="line">
                        <div class="line-title">1.1 服务内容</div>
                        <div class="line-content">本协议中服务指的是 SpeedFox 向您提供游戏网络优化服务。使用者及用户有权在服务期限内合理使用相关产品。</div>
                    </div>
                    <div class="line">
                        <div class="line-title">1.2 服务对象</div>
                        <div class="line-content">我们仅对智商正常，且有素质的用户提供服务，我们有权封禁账号，撤回使用权限。</div>
                    </div>
                </div>
                <div class="content-box">
                    <h5 class="row">二、SpeedFox 的获取、安装、更新和卸载</h5>
                    <div class="line">2.1 您可直接从官网获取 SpeedFox。</div>
                </div>
                <div class="content-box">
                    <h5 class="row">三、极狐账号</h5>
                    <div class="line">3.1 极狐账号是指从官网注册的账号，使用极狐产品需要注册登录账号才可以正常使用。</div>
                    <div class="line">3.2 您应对您的账号负责，只有您本人可以使用您的极狐账号，该账号不可转让、不可赠与、不可继承、您只拥有账号的使用权而不是所有权。</div>
                    <div class="line">3.3 您应妥善保管并正确、安全地使用账号及密码，对使用该账号及密码进行的一切操作负完全的责任。若发现转让、赠与等问题，我们有权暂停你的账号</div>
                </div>
                <div class="content-box">
                    <h5 class="row">四、数据信息保护</h5>
                    <div class="line">4.1 我们致力于保护您的信息安全，并为此采取合理的预防措施。除法律法规规定的情形和您的许可外，我们不会向第三方公开、透露您的个人信息。</div>
                    <div class="line">4.2 在本软件安装和使用过程中，本软件将发送本软件的设备的信息，该信息包括本软件的版本、语言、设备的IP地址、硬件配置信息。</div>
                    <div class="line">4.3 您可阅读我们网站上发布的《隐私声明》进一步了解如何收集、使用、存储和保护您的个人信息及您享有何种权利。该《隐私政策》可能会不时更新，在上述更新发布后继续使用本软件服务即表示您同意新的条款。</div>
                    <div class="line">4.4 如果您未满18周岁，您在使用本软件前须取得法定监护人的书面同意。</div>
                </div>
                <div class="content-box">
                    <h5 class="row">五、用户使用规范</h5>
                    <div class="line">
                        <div class="line-title">5.1 除非法律允许、本协议另有规定或书面许可外，您不得从事下列行为：</div>
                        <div class="line-content">(1) 出租、出借、分许可、出售、复制、修改或传播本软件，或基于SpeedFox创造衍生作品，或促使或允许他人作上述行为；</div>
                        <div class="line-content">(2) 以任何形式或为任何目的，直接或间接对本软件进行修改、翻译、反向工程、反向汇编、反向编译、转换为其他编程语言或者以其他方式尝试发现本软件的源代码或由本软件产生的内在数据文件，或对本协议项下获取的任何软件或固件进行任何类似操作；</div>
                        <div class="line-content">(3) 对本软件或者本软件运行过程中释放到任何终端内存中的数据、软件运行过程中客户端与服务器端的交互数据以及本软件运行所必需的系统数据，予以复制、修改、增加、删除、挂接运行或创作任何衍生作品，包括但不限于使用插件、外挂或非经授权的第三方工具/服务接入本软件和相关系统；</div>
                        <div class="line-content">(4) 通过修改或伪造本软件运行中的指令、数据，增加、删减、变动本软件的功能或运行效果，或者将用于上述用途的软件、方法进行运营或向公众传播，无论这些行为是否为商业目的；</div>
                        <div class="line-content">(5) 通过非SpeedFox开发、授权的第三方软件、插件、外挂、系统，登录或使用本软件及SpeedFox服务，或制作、发布、传播上述工具；</div>
                        <div class="line-content">(6) 自行、授权他人或利用第三方软件对本软件及其组件、模块、数据等进行干扰；</div>
                        <div class="line-content">(7) 任何危害本软件或利用本软件危害计算机网络安全的行为；</div>
                        <div class="line-content">(8) 以意图规避SpeedFox服务条款、违反相应法律法规的方式或超出正常使用范围而使用本软件；</div>
                        <div class="line-content">(9) 通过本软件或SpeedFox服务向他人发送、诱导或煽动他人发送大量信息； </div>
                        <div class="line-content">(10) 其他未经SpeedFox明示授权、许可或违反本协议的行为。</div>
                    </div>
                    <div class="line">
                        <div class="line-title">5.2 在使用本软件和/或SpeedFox服务时，您不得从事下列行为，或为下列行为提供帮助：</div>
                        <div class="line-content">(1) 上传、发布、传送、传播或使用违反国家法律、危害国家安全统一、社会稳定、公序良俗、社会公德以及侮辱、诽谤、淫秽、暴力的内容；</div>
                        <div class="line-content">(2) 上传、发布、传送、传播或使用侵害他人名誉权、肖像权、知识产权、商业秘密等合法权利的内容；</div>
                        <div class="line-content">(3) 上传、发布、传送、传播或使用涉及他人隐私、个人信息或资料的内容；</div>
                        <div class="line-content">(4) 发布、传送、传播骚扰、广告信息及垃圾信息；</div>
                        <div class="line-content">(5) 虚构事实、隐瞒真相以误导、欺骗他人；</div>
                        <div class="line-content">(6) 发布、传送、传播广告信息及垃圾信息；或</div>
                        <div class="line-content">(7) 从事其他违反法律法规、政策及公序良俗、社会公德等的行为。</div>
                    </div>

                    <div class="line">5.3 您应妥善保管登录和使用本软件和服务的信息及密码，不向他人透露，并对您未妥善保管账户信息及密码所受到的损失承担全部责任。</div>
                </div>
                <div class="content-box">
                    <h5 class="row">六、用户行为责任</h5>
                    <div class="line">6.1 您充分了解并同意，您必须为自己使用本软件服务的一切行为负责，包括您利用本软件服务储存、发布、传送、传播的任何内容以及由此产生的任何后果。</div>
                    <div class="line">6.2 如发现或收到他人举报您有违反本协议或相关法律法规的行为，我们将采取包括但不限于终止授权许可、停止技术支持、向有关部门移交线索、追究法律责任等措施。您同意并确认这是我们为维护健康良好的网络环境而采取的必要措施，若由于我们按照前述约定采取措施而对您产生影响或任何损失的，您同意不追究任何责任或不向我们主张任何权利。</div>
                </div>

                <div class="content-box">
                    <h5 class="row">七、免责申明</h5>
                    <div class="line">7.1 您明确认可并同意，您使用SpeedFox软件需自行承担风险，并承担有关质量满意度、性能、准确性及结果等方面的全部风险。您进一步理解并同意，根据目前行业技术发展水平，尚无法保证完全不发生故障或系统没有漏洞及程序不会出错，并可能因此产生人身或财产损害的风险，您在使用SpeedFox时应采取必要的措施保障安全性，包括但不限于安全防护措施、数据备份措施等。</div>
                    <div class="line">7.2 安装SpeedFox软件可能影响第三方软件、应用软件或第三方服务的可用性，您在安装、使用SpeedFox的全过程中应自行采取必要的措施以避免对您造成损失，包括但不限于使用环境测试、数据备份等。</div>

                    <div class="line">7.3 互联网传输无法保证100%的安全，您确认具有互联网安全知识，能够自行承担信息传输过程中可能产生的风险。</div>
                    <div class="line">7.4 我们不因不可抗力造成的本软件服务的中断或故障承担责任，不可抗力包括但不限于自然灾害、战争行为、恐怖活动、骚乱、革命、罢工等社会因素、立法变化、政策修改、政府行为及命令、电信部门技术调整等不能预见、不能避免并不能克服的客观情况。</div>
                    <div class="line">7.5 在任何情况下，不因您使用本软件服务所引起的、或在任何方面与本软件服务有关的任何数据或个人或商业信息的丢失或损坏、任何意外的、间接的、特殊的、惩罚性的、或附带的损害或请求（包括但不限于业务利润损失、业务中断、信息泄露、数据丢失、金钱损失、或取得替代产品及服务的费用）承担责任。</div>
                    <div class="line">7.6 我们向您免费提供软件许可，作为免费使用本软件的代价，除本协议另有约定外，我们对本协议项下所有事项不承担责任，不论是合同、侵权或其他责任。本责任限制条款在本协议第7.3条软件保证救济不能完全弥补您的损失时仍然适用。</div>
                    <div class="line">7.7 您理解并同意，为了向您提供有效的服务，本软件会利用你终端设备的处理器和带宽等资源。本软件使用过程中可能产生数据流量费用，该费用由您承担。</div>
                </div>
                
                
                
                <div class="content-box">
                    <h5 class="row">八、未成年人使用条款</h5>
                    <div class="line">8.1 若您未满18周岁，则为未成年人，您应当在监护人的监护、指导下阅读本协议以及使用及相关服务。</div>
                    <div class="line">8.2 监护人应对未成年人使用SpeedFox及服务时加以监督和引导。</div>
                </div>
                <div class="content-box">
                    <h5 class="row">九、退款政策</h5> 
                    <div class="line">9.1 虚拟产品不支持任何退款，若没有使用，可按照比例退款。</div>
                    <div class="line">9.2 双方发生争议时，所有因本协议引起的或与本协议有关的任何争议，双方应首先通过友好协商解决；如协商未果，任何一方可提交本公司住所地有管辖权的人民法院解决。</div>
                </div>
                <div class="content-box">
                    <h5 class="row">十、其他</h5>
                    <div class="line">10.1 您使用SpeedFox软件即视为您已阅读并同意受本协议的约束。SpeedFox有权在必要时修改本协议条款。您可以在SpeedFox软件的最新版本中查阅相关协议条款。本协议条款变更后，如果您继续使用SpeedFox软件，即视为您已接受修改后的协议。如果您不接受修改后的协议，应当停⽌使用SpeedFox软件。</div>
                </div>
            </div>
            <div class="conter_shadow shadow_bottom"></div>
        </div>


        <div class="conter_select">
            <div class="select_tips">测试内容</div>
            <label class="ubind_click">
                <div class="select_ground"><span></span></div>
                <span style="color: #8f8f8f;">我已仔细阅读《使用说明》 并同意 《用户协议》 </span>
            </label>
        </div>
        <div class="conter_btns">
            <button class="btn btn_submit disabled" onclick="open_panel()">同意并注册账号</button>
        </div>
    </div>
    <script type="text/javascript">
        var is_scroll = false,is_checked = false,out_time = null;
        var ubind_click = document.getElementsByClassName('ubind_click')[0],
            _select_btn = document.getElementsByClassName('btn_submit')[0];
        ubind_click.addEventListener('click', function (){
            if(!is_scroll){
                set_licenes({msg:'请仔细看完 《使用说明》 和 《用户协议》'})
                return false;
            }
            var select_ground = this.getElementsByClassName('select_ground')[0],
            btn_submit = document.getElementsByClassName('btn_submit')[0];
            if (hasClass(select_ground,'pitch')) {
                removeClass(select_ground, 'pitch');
                addClass(btn_submit,'disabled');
                is_checked = false;
            } else {
                addClass(select_ground,'pitch');
                removeClass(btn_submit,'disabled');
                is_checked = true;
            }
        },false);
        document.getElementsByClassName('conter_tips')[0].onscroll = function(e){
            var conter_shadow = document.getElementsByClassName('conter_shadow'),
            conter_read_tips = document.getElementsByClassName('conter_read_tips')[0],
            conter_text = conter_read_tips.getElementsByTagName('span')[0]
            var scrollHeight = this.scrollHeight - this.clientHeight -10;
            console.log(this.scrollTop,scrollHeight)
            if(this.scrollTop === 0){
                replaceClass(conter_shadow[0],'show','hide');
                replaceClass(conter_shadow[1],'hide','show');
            }else if(this.scrollTop > 0 && this.scrollTop < scrollHeight){
                replaceClass(conter_shadow[0],'hide','show');
                replaceClass(conter_shadow[1],'hide','show');
            }else if(this.scrollTop > scrollHeight){
                replaceClass(conter_shadow[0],'hide','show');
                replaceClass(conter_shadow[1],'show','hide');
                is_scroll = true;
            }
            if(!is_scroll){
                conter_text.innerText = Math.round(this.scrollTop / scrollHeight * 100) + '%';
            }else{
                addClass(conter_read_tips,'active');
                conter_read_tips.innerText = '已完成阅读'
            }
        }
        // 主视图自适应
        function auto_mian(){
            var win_height = window.innerHeight,
            main = document.getElementsByClassName('main')[0];
            conter_tips = main.getElementsByClassName('conter_tips')[0];
            main.style.cssText = 'display:block;height:'+ (win_height - 50) +'px;'
            conter_tips.style.height =  (win_height - 380) + 'px'
        }
        //判断class是否存在
        function hasClass(elem, cls) {
            cls = cls || '';
            if (cls.replace(/\s/g, '').length == 0) return false;
            return new RegExp(' ' + cls + ' ').test(' ' + elem.className + ' ');
        }

        //添加class
        function addClass(elem, cls) {
            if (!hasClass(elem, cls)) {
                elem.className = elem.className == '' ? cls : elem.className + ' ' + cls;
            }
        }

        //删除class
        function removeClass(elem, cls) {
            if (hasClass(elem, cls)) {
                var newClass = ' ' + elem.className.replace(/[\t\r\n]/g, '') + ' ';
                while (newClass.indexOf(' ' + cls + ' ') >= 0) {
                    newClass = newClass.replace(' ' + cls + ' ', ' ');
                }
                elem.className = newClass.replace(/^\s+|\s+$/g, '');
            }
        }

        //替换class
        function replaceClass(elem,cls,newCls){
            removeClass(elem,cls);
            addClass(elem,newCls);
        }

        // 打开面板
        function open_panel(){
            if(!is_scroll){
                set_licenes({msg:'请下拉滚动条并阅读‘《用户协议》’'});
                return false;
            }
            if(!is_checked){
                set_licenes({msg:'请勾选已阅读并同意《用户协议》选项'});
                return false;
            }
            window.location.href = 'register.php'
        }
        // 设置消息提示
        function set_licenes(config) {
            var select_tips = document.getElementsByClassName('select_tips')[0];
            select_tips.innerText = config.msg;
            select_tips.style.display = 'block';
            clearTimeout(out_time);
            out_time = setTimeout(function(){
                select_tips.style.display = 'none';
            },config.time || 3000);
        }

        window.onresize = function () {
            auto_mian();
        }
        window.onload = function(){
            auto_mian();
        }
    </script>
</body>
</html>