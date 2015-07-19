String.prototype.Concat = function (string2) {
    var string1 = this;
   
    var string3 = string1;
    for (i = 0; i < string2.length; i++) {
        string3 += string2.charAt(i);
    }
 return string3;

};