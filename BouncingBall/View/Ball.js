window.ball = window.ball || {
    previousLeft : 0,
 previousTop : 0,
 deltaX : 10,
 deltaY : 10

};

ball.bounce = function ()
{
    var element = document.getElementById('circle');
    element.style.left = ball.previousLeft + "px";
    element.style.top = ball.previousTop + "px";

    ball.container();
    ball.previousLeft += ball.deltaX;
    ball.previousTop += ball.deltaY;
   
    
}
window.ball.start = function () {
    setInterval(ball.bounce, 10);
}