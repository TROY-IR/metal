

       //         import * as THREE from
        //    "https://cdn.jsdelivr.net/npm/three@0.179.1/build/three.module.js";


        const khodecore = document.querySelector('.khodecore');
        const body = document.querySelector('.body');
        const col = document.querySelector('.col');
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


        m_daste.forEach(a1 => {
            a1.style.marginLeft = a * parseFloat(getComputedStyle(a1).marginLeft) + "px"

        });

        //  searchBar.style.width = parseFloat(getComputedStyle(col).width) * 0.9 + 'px'


        const cr = document.querySelector('.t');
        let isnew = false
        let cha = 0
        let tp = false
        let tp1 = false
        let tp2 = false
        let tp3 = false
        let tp4 = false
        var ww = window.innerWidth
        var wh = window.innerHeight

        if (window.innerWidth / window.innerHeight >= 1.5) {

            const saf = document.querySelector('.saf')


            khodecore.style.height = 100 + '%'


            const eleman = document.querySelector('.eleman')
            const eleman1 = document.querySelector('.eleman1')

            const eleman2 = document.querySelector('.eleman2')
            const eleman3 = document.querySelector('.eleman3')
            const eleman4 = document.querySelector('.eleman4')
            const eleman5 = document.querySelector('.eleman5')
            const eleman6 = document.querySelector('.eleman6')

            const eleman7 = document.querySelector('.eleman7')
            const eleman8 = document.querySelector('.eleman8')
            const groh = document.querySelector('.groh')

            const tablo = document.querySelectorAll('.tablo')
            const head = document.querySelectorAll('.head')

            const radif = document.querySelectorAll('.radif')
            const radif1 = document.querySelectorAll('.radif1')

            const te = document.querySelectorAll('.te')
            const h = document.querySelectorAll('.h')

            const r = document.querySelectorAll('.r')
            const rr = document.querySelectorAll('.rr')

            const gk1 = document.querySelectorAll('.gk1')
            const gkk = document.querySelectorAll('.gkk')
            const acsk = document.querySelectorAll('.acsk')

            eleman.style.width = ww * 0.5 + 'px'
            eleman.style.height = ww * 0.5 + 'px'
            eleman.style.background = 'none'

            eleman1.style.width = ww * 0.49 + 'px'
            eleman1.style.height = ww * 0.5 + 'px'
            eleman1.style.background = 'none'

            eleman2.style.width = ww * 0.49 + 'px'
            eleman2.style.height = ww * 0.5 + 'px'
            eleman2.style.background = 'none'

            eleman3.style.width = ww * 0.49 + 'px'
            eleman3.style.height = ww * 0.5 + 'px'
            eleman3.style.background = 'none'

            eleman4.style.width = ww * 0.49 + 'px'
            eleman4.style.height = ww * 0.5 + 'px'
            eleman4.style.background = 'none'

            eleman5.style.width = ww * 0.49 + 'px'
            eleman5.style.height = ww * 0.5 + 'px'
            eleman5.style.background = 'none'

            eleman6.style.width = ww * 0.32 + 'px'
            eleman6.style.height = ww * 0.32 + 'px'
            eleman6.style.background = 'none'

            eleman7.style.width = ww * 0.32 + 'px'
            eleman7.style.height = ww * 0.32 + 'px'
            eleman7.style.background = 'none'

            eleman8.style.width = ww * 0.32 + 'px'
            eleman8.style.height = ww * 0.32 + 'px'
            eleman8.style.background = 'none'


            gk1.forEach(r => {

                r.style.width = ww * 0.09 + 'px'
                r.style.height = ww * 0.09 + 'px'
            })
            gkk.forEach(r => {

                r.style.width = ww * 0.06 + 'px'
                r.style.height = ww * 0.11 + 'px'
            })
            acsk.forEach(r => {
                r.style.width = ww * 0.06 + 'px'
                r.style.height = ww * 0.09 + 'px'

            })


            //eleman1.style.marginLeft = ww * 0.005 + 'px'
            //eleman1.style.marginLeft = ww * 0.5 + 'px'
            // eleman2.style.width = ww *  0.33 + 'px'
            //  eleman2.style.height = ww * 0.33 + 'px'

            //    eleman3.style.width = ww *  0.33 + 'px'
            //    eleman3.style.height = ww * 0.33 + 'px'

            //   eleman4.style.width = ww *  0.33 + 'px'
            //   eleman4.style.height = ww * 0.33 + 'px'


            radif.forEach(r => {
                r.style.marginTop = ww * 0.34 + 'px'
                r.style.height = ww * 0.13 + 'px'

            })
            radif1.forEach(r => {
                r.style.marginTop = ww * 0.21 + 'px'
                r.style.height = ww * 0.13 + 'px'
                r.style.width = ww * 0.48 + 'px'
            })
            tablo.forEach(t => {
                t.style.width = ww * 0.48 + 'px'
                t.style.height = ww * 0.48 + 'px'
            })
            head.forEach(h => {
                h.style.width = ww * 0.48 + 'px'
                h.style.height = ww * 0.32 + 'px'
            })

            r.forEach(r => {
                r.style.marginTop = ww * 0.22 + 'px'
                r.style.height = ww * 0.09 + 'px'

            })
            rr.forEach(r => {
                r.style.marginTop = ww * 0.14 + 'px'
                r.style.height = ww * 0.09 + 'px'
                r.style.width = ww * 0.31 + 'px'
            })
            te.forEach(t => {
                t.style.width = ww * 0.31 + 'px'
                t.style.height = ww * 0.31 + 'px'
            })
            h.forEach(h => {
                h.style.width = ww * 0.31 + 'px'
                h.style.height = ww * 0.20 + 'px'
            })


            groh.style.width = ww

            const core = document.querySelector('.core')
            const daste = document.querySelector('.daste')
            core.style.height = wh * 0.6 + 'px'
            core.style.width = 100 + '%'
            core.style.display = 'flex'
            core.style.flexWrap = 'nowrap'
            core.style.marginTop = 100 + 'px'

            player.style.width = 55 + '%'
            player.style.height = 100 + '%'
            player.style.marginTop = 0 + '%'

            khodecore.style.width = 50 + '%'
            khodecore.style.position = 'absolute'
            khodecore.style.marginLeft = 50 + '%'

            daste.style.width = 100 + '%'
            groh.style.width = 100 + '%'

            cha = 1
            serinp.style.width = 45 + '%'
            serinp.style.marginLeft = 52 + '%'


            //    bo1.style.width = 20 + '%'
            //    bo.style.width = 10 + '%'
            //    bo.style.marginLeft = 73 + '%'

            console.log(window.innerWidth / window.innerHeight)

            cr.src = '/ko2.png'
            //  cr.style.marginLeft = -420 + 'px'
            const t = document.querySelector('.t');

            t.style.marginLeft = 4 + '%'

  } else {

         //   win = false
        }


        if (window.innerWidth / window.innerHeight < 1.5) {




         const  foter = document.querySelectorAll('.foter')
          const  foter0 = document.querySelectorAll('.foter0')
          const  fim = document.querySelectorAll('.fim')

            foter.forEach(f => {

                f.style.flexWrap = 'wrap'
                f.style.height = 0.65 * wh
                f.style.width = 95 + '%'
                f.style.marginLeft = 2 + '%'
            })
            foter0.forEach(f => {
                f.style.height = 55 + '%'
                f.style.width = 100 + '%'

                f.style.position = 'absolute'
                f.style.marginTop = 45 + '%'

            })
            fim.forEach(f => {
                f.style.width = 100 + '%'
                f.style.height = 45 + '%'

                f.classList.add('mfim')
            })









            const ba = document.getElementById('idaste');
            const base = ba.offsetWidth;

            const all0 = document.querySelectorAll(".photo,.core,.khodecore,.acs,.mtn,.tablo,.mini,.mini1,.radif,.radif1,.head,.tablo,.core,.eleman,.eleman1,.eleman2,.eleman3,.eleman4,.eleman5,.eleman6,.eleman7,.eleman8,.groh")
            const all = document.querySelectorAll(".poster,.daste,.photo,.core,.khodecore,.acs,.mtn,.tablo,.mini,.mini1,.radif,.radif1,.head,.tablo,.core,.eleman,.eleman1,.eleman2,.eleman3,.eleman4,.eleman5,.eleman6,.eleman7,.eleman8,.groh")
            const all2 = document.querySelectorAll(".mtn,.gk,.acs,.mtn,.head,.eleman,.eleman1,.eleman2,.eleman3,.eleman4,.eleman5,.eleman6,.eleman7,.eleman8,.groh")
            const d = document.querySelector('.daste')


            all.forEach(a1 => {
                const p0 = parseFloat(getComputedStyle(a1).width) / ww
                const p = parseFloat(getComputedStyle(a1).width) * a;
                const p1 = parseFloat(getComputedStyle(a1).height) * p0;
                a1.style.width = 100 + "%";
                //   a1.style.height = p1 + "px";


            });
            all2.forEach(a1 => {
                const p2 = parseFloat(getComputedStyle(a1).marginTop) * a;

                a1.style.marginTop = p2 + "px";

            });


            fot.forEach(ch0 => {
                ch0.style.width = 100 + '%'

                Array.from(ch0.children).forEach(ch1 => {
                    const p = parseFloat(getComputedStyle(ch1).width);
                    const p1 = parseFloat(getComputedStyle(ch1).height);
                    ch1.style.height = p1 * (window.innerWidth / 1200) + 'px'
                    ch1.style.width = p * (window.innerWidth / 1200) + 'px'

                    const pp = parseFloat(getComputedStyle(ch1).marginLeft);
                    const pp1 = parseFloat(getComputedStyle(ch1).marginTop);
                    ch1.style.marginTop = pp1 * (window.innerWidth / 1200) + 'px'
                    ch1.style.marginLeft = pp * (window.innerWidth / 1200) + 'px'

                })
            })


            const gk = document.querySelector('.gk')
            const acs = document.querySelector('.acs')



            gk.style.width = 30 + '%'
            gk.style.height = 20 + '%'

            acs.style.width = 80 + '%'
            acs.style.height = 100 + '%'

        }





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




        if (window.innerWidth / window.innerHeight > 1.5) {



            fot.forEach(ch0 => {
                ch0.style.width = window.innerWidth + 'px'
                Array.from(ch0.children).forEach(ch1 => {
                    const p = parseFloat(getComputedStyle(ch1).width);
                    const p1 = parseFloat(getComputedStyle(ch1).height);
                    ch1.style.height = p1 * (window.innerWidth / 2100) + 'px'
                    ch1.style.width = p * (window.innerWidth / 2100) + 'px'

                    const pp = parseFloat(getComputedStyle(ch1).marginLeft);
                    const pp1 = parseFloat(getComputedStyle(ch1).marginTop);
                    ch1.style.marginTop = pp1 * (window.innerWidth / 2100) + 'px'
                    ch1.style.marginLeft = pp * (window.innerWidth / 2100) + 'px'
                })
            })
        }





