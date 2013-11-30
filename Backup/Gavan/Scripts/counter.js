var x = self.setInterval(function () { counter() }, 1000);
var i = 4;
function counter() {
    if (i == 1) {
        window.clearInterval(x)
        return;
    }
    i--;
    document.getElementById("counter").innerHTML = i;
}