window.onload=function(){
    /*跟布局有关的代码 */

    function setMask(){
    /* 遮罩 2018/9/23   jx*/    
        $('.mask').height(0);
        $('.mask').width(0);
        let winHeights =[$(window).height(),$(document).height(),$(document.body).height(),$(document.body).outerHeight(true)];
        let winWidths = [$(window).width(),$(document).width(),$(document.body).width(),$(document.body).outerWidth(true)]
        var maxHeight = winHeights.sort((one,two)=> one<two)[0];
        var maxWidth = winWidths.sort((one,two)=> one<two)[0];
        $('.mask').height(maxHeight);
        $('.mask').width(maxWidth);
    }

    function setContentCenter(){
    /* 遮罩 内容居中 2018/9/23 jx*/        
        let winWidthView = $(window).width();  //得到可视区域的宽度
        let winHeightView = $(window).height();  //得到可视区域的高度

        let content =$(".mask-content");
        let oWidth  = content.width(); //得到内容块的宽度
        let oHeight = content.height(); //得到内容块的高度
        let left = ( winWidthView - oWidth)/2;  //得到偏离宽度
        let top = ( winHeightView - oHeight)/2 - 75; //得到偏离高度

        let contentLeft = (winWidthView - $(".layout-center").width())/2;  //得到偏离宽度
        let contentTop  = (winHeightView - $(".layout-center").height())/2 - 75; //得到偏离高度
            
        content.css({
            "left":left+"px",
            "top":top+"px"
        });

        $(".layout-center").css({
            "left":contentLeft+"px",
            "top":contentTop+"px"
        })
    };
    function setFlexHeightHalf(){
        $(".flex-height-half").css({
            "height":($(window).height()/2) +"px"
        });         
    };

    window.addEventListener("resize",function(){
        setMask();
        setContentCenter();
        setFlexHeightHalf();
    },false);
    
    $('.mask-module-close').on('click',function(){
        $('.mask-content').hide();
        $('.mask').hide();
    });

    setMask();
    setContentCenter();
    setFlexHeightHalf();

}