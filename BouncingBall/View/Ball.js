

bouncingBall=bouncingBall ||{};
window.bouncingBall.ball= function (ballId){
   
       var  previousLeft = 0,
         previousTop = 0,
         deltaX = 10,
         deltaY = 10,  
           
          element = document.getElementById(ballId);
        
return
{
    previousLeft:previousLeft,
    previousTop : previousTop,
    bounce : function(){

    }

        element.style.left = previousLeft + "px";
        element.style.top = previousTop + "px";
        var p = new ball.container();
        deltaX = p.deltaXChange();
        deltaY = p.deltaYChange();
        previousLeft += deltaX;
        previousTop += deltaY;
    
    
       var getPreviousLeft = function(){
            return this.previousLeft;
        };
       
        var getPreviousTop= function () {
            return this.previousTop;
        };
        //getDeltaX: function () {
        //    return this.deltaX;
        //},
        //getDeltaY: function () {
        //    return this.deltaY;
        //},
        var setDeltaX= function (x) {
            this.deltaX=x;
        };
        
        var setDeltaY= function (y) {
            this.deltaY=y;
        };
    }
}

     function start() {
        
    setInterval(ball.bounce, 10);
    }
