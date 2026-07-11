const all = document.querySelectorAll(".d1,.db")
//const all2 = document.querySelectorAll(".in,.d2,in1,in2,.Name,.Age,.Last,.Number,.se1,.se,.ch,.ro,.rol,.su,.link")
//const all2 = document.querySelectorAll(".in,.d2,in1,in2,.Name,.Age,.Last,.Number,.se1,.se,.ch,.ro,.rol,.su,.link")
const all3 = document.querySelector(".d1")

var aw = parseFloat(getComputedStyle(all3).width) / window.innerWidth * 0.8;
var ah = parseFloat(getComputedStyle(all3).height) / window.innerHeight * 0.9;

all.forEach(a1 => {
    const p = window.innerWidth * 0.8;
    const p1 = window.innerHeight * 0.9;
    a1.style.width = p + "px";
    a1.style.height = p1 + "px";


});

const p2 = window.innerHeight * 0.05;
all3.style.marginTop = p2 + "px";

//all2.forEach(a1 => {
//  a1.stylr.marginTop = parseFloat(getComputedStyle(a1).height) * (ah)

//});

all3.style.marginLeft = window.innerWidth * 0.1 + "px"
//all2.forEach(a1 => {
//   a1.stylr.marginLeft = parseFloat(getComputedStyle(a1).left) * (aw)

//});

