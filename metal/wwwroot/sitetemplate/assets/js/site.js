

       //         import * as THREE from
        //    "https://cdn.jsdelivr.net/npm/three@0.179.1/build/three.module.js";


        const khodecore = document.querySelector('.khodecore');
        const body = document.querySelector('.body');
        const searchBar = document.querySelector('.search-bar');
        const search = document.getElementById('.search');
        const m_daste = document.querySelectorAll('.t,.khodecore,.matn,.matn1,.m_daste,.day');
        const bo = document.querySelector(".bu")
        const bo1 = document.querySelector(".bu1")
        const serinp = document.querySelector(".serinp")
        const player = document.querySelector(".photo");
        const fot = document.querySelectorAll('.foter0')
        const groh = document.querySelector('.groh')
        const add = document.querySelector(".add");
        const body1 = document.querySelector(".body1");
        const f12 = document.querySelector(".f12");
        const favrate = document.querySelector(".favrate");

        var ww = window.innerWidth
        const a = window.innerWidth / 500;


        const inf = 0;

        window.addEventListener('scroll', () => {

            if (window.scrollY >= 50) {
                // searchBar.style.borderRadius = "18px";
                searchBar.classList.add('p') // انتقال به پایین صفحه
            } else {
                //   searchBar.style.borderTopLeftRadius = "0px"
                //   searchBar.style.borderTopRightRadius = "0px"
                searchBar.classList.remove('p') // بازگشت به بالا
            }
        });






        const catbb = document.querySelectorAll('.catbb')
        const cab = document.querySelectorAll('.cab')
        const catb2 = document.querySelectorAll('.catb2')
        const catb3 = document.querySelectorAll('.catb3')

catbb.forEach(c => {
    let count = 0
    let cv = parseFloat(getComputedStyle(c).width)
    let cv1 = parseFloat(getComputedStyle(c.firstElementChild).width)
    let mal = 0
    c.addEventListener('mouseenter', () => {

        c.style.width = parseFloat(getComputedStyle(c).width) * 0.85 * c.childElementCount + 'px'

        Array.from(c.children).forEach(ch => {

            ch.style.zIndex = 2000 - count
            ch.style.width = (parseFloat(getComputedStyle(c).width) * 0.85) + 'px'
            if (count != 0) {
                ch.style.marginLeft = count * parseFloat(getComputedStyle(ch).width) * 0.75 + 'px'

            }
            count = count + 1


        })
    })
    c.addEventListener('mouseleave', () => {
        count = 0
        c.style.width = 15 + '%'
        if (parseFloat(getComputedStyle(c).width) < 110) {
            c.style.width = parseFloat(getComputedStyle(c).minWidth) + 'px'
        }
        Array.from(c.children).forEach(ch => {
            ch.style.marginLeft = 0
            ch.style.width = 100 + '%'
        })
    })


})









