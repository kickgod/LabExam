$(function(){
    // 全高度
    function set_layout_height_100(){
        let winHeights =[$(window).height(),$(document).height(),$(document.body).height(),$(document.body).outerHeight(true)];
        var maxHeight = winHeights.sort((one,two)=> one < two)[0];        
        $('.layout-height-100').height(maxHeight);
    }
    $(window).on('resize',null,null,set_layout_height_100);
    set_layout_height_100();  

    $(document).on('DOMSubtreeModified',null,null,set_layout_height_100);

    /* 设置高度 */
    $('[data-height]').height(function(index, height){
        let dom = $(this);
        return dom.attr('data-height');
    });
    /* 设置宽度 */
    $('[data-width]').width(function(index, width){
        let dom = $(this);
        return dom.attr('data-width');
    });
    /* 设置最小宽度 */ 
    $('[data-min-width]').css('min-width',function(index,width){
        return `${$(this).attr('data-min-width')}px`;
    });
    /* 设置最大宽度 */ 
    $('[data-max-width]').css('max-width',function(index,width){
        return `${$(this).attr('data-max-width')}px`;
    });

    $('[data-margin-top]').css('margin-top',function(index,width){
        return `${$(this).attr('data-margin-top')}px`;
    });

});