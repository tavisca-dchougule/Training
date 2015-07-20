String.prototype.Concat = function () {

    var firstString = this;
    for (var i = 0; i < arguments.length; i++) {
        if (arguments[i] == "null")
            firstString += "null";
        if (arguments[i] == "undefined")
            firstString += "undefined";
        firstString += arguments[i];
    }
 return firstString;

};