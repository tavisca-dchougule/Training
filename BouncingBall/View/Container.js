

bouncingBall=bouncingBall ||{};

   bouncingBall.container: function () {

        var height = (window.innerHeight - 50);
        var width = (window.innerWidth - 50);
        var deltaXChange = function () {
            

            if (ball.getPreviousLeft() >= width) {
             
                return -10;
            }
            if (ball.getPreviousLeft() <= 0) {
             
                return 10;
            }
        }
        var deltaYChange = function () {
            
            if (ball.getPreviousTop() <= 0) {
                
                return 10;
            }
            if (ball.getPreviousTop() >= height) {
                
                return -10;
            }
           
        }

           
            
        
    }
