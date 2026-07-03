async function loadData() {

    const response = await fetch('/Home/Db');

    console.log(response.status);

    const posters = await response.json();

    console.log(posters.length);
    console.log(posters);
    for (const tname in posters) {
        //   const eleman = document.querySelector(`.eleman${i}`)
        const rows = posters[tname]
        console.log(rows.length);
        for (let i1 = 0; i1 < rows.length; i1++) {
            // eleman.firstChild.children[1]
            //  const mah = document.createElement('img')
            //   mah.classList.add('mah', 'mini')
           
            //   mah.src = rows[i1].src
            console.log(rows[i1].src);
        }
    }
}
 //   loadData();




const khodecore = document.querySelector('.khodecore');
const body = document.querySelector('.body');
const col = document.querySelector('.col');
const searchBar = document.querySelector('.search-bar');
const search = document.getElementById('.search');
const m_daste = document.querySelectorAll('.t,.khodecore,.matn,.matn1,.m_daste,.day');
const bo = document.querySelector(".bu")
const bo1 = document.querySelector(".bu1")




const videos = [
    "/sitetemplate/assets/video/video1.mp4",
    "/sitetemplate/assets/video/video2.mp4",
    "/sitetemplate/assets/video/video3.mp4"
];

const player = document.querySelector(".photo");

let currentIndex = 0;
let pausedAt5 = false;

function playVideo(index) {
    if (index >= videos.length) {
        currentIndex = 0; // شروع دوباره از اول
    }

    pausedAt5 = false;

    player.src = videos[currentIndex];
    player.load();

    player.onloadedmetadata = () => {
        player.play();
    };
}

player.addEventListener("timeupdate", () => {


    if (!pausedAt5 && player.currentTime >= 5) {

        const core = document.querySelector('.core')

        const hpo = document.createElement('img')


        core.appendChild(hpo)


        hpo.classList.add('hpo')
        hpo.src = '/sitetemplate/assets/image/otherimg/men.jpg'
        hpo.style.width = (80 * a) + 'px'
        hpo.style.height = (115 * a) + 'px'

        setTimeout(() => {
            hpo.classList.add('show')
        }, 350)
        pausedAt5 = true;
        player.pause();


        setTimeout(() => {
            const hpo1 = document.querySelector('.hpo')
            if (hpo1 != null) {
                hpo1.remove()
            }
            currentIndex++;

            if (currentIndex >= videos.length) {
                currentIndex = 0;
            }

            playVideo(currentIndex);


        }, 4000); // مکث 4 ثانیه‌ای


    }
});


playVideo(currentIndex);









const inf = 0;

window.addEventListener('scroll', () => {

    if (window.scrollY >= 50) {
        searchBar.style.borderRadius = "18px";
        searchBar.classList.add('p') // انتقال به پایین صفحه
    } else {
        searchBar.style.borderTopLeftRadius = "0px"
        searchBar.style.borderTopRightRadius = "0px"
        searchBar.classList.remove('p') // بازگشت به بالا
    }
});

const ba = document.getElementById('idaste');
const base = ba.offsetWidth;
const a = window.innerWidth / base;

const all = document.querySelectorAll(".photo,.gk,.core,.khodecore,photo.gk,.acs,.mtn,.day,.m_daste,.tablo,.po,.po_f,.po_f1,.po_f2,.mini,.mini1,.radif,.radif1,.head,.tablo,.core,.daste,.poster,.poster1,.eleman0,.eleman1,.eleman2,.eleman3,.eleman4,.eleman5,.eleman6,.eleman7,.eleman8,.poster2,.poster3,.groh")
const all2 = document.querySelectorAll(".mtn,.gk,.acs,.mtn,.po,.day,.head,.radif,.radif1,.poster,.poster1,.eleman0,.eleman1,.eleman2,.eleman3,.eleman4,.eleman5,.eleman6,.eleman7,.eleman8,.poster2,.poster3,.groh")

all.forEach(a1 => {
    const p = parseFloat(getComputedStyle(a1).width) * a;
    const p1 = parseFloat(getComputedStyle(a1).height) * a;
    a1.style.width = (p * 0.99) + "px";
    a1.style.height = p1 + "px";


});
all2.forEach(a1 => {
    const p2 = parseFloat(getComputedStyle(a1).marginTop) * a;

    a1.style.marginTop = p2 + "px";

});
m_daste.forEach(a1 => {
    a1.style.marginLeft = a * parseFloat(getComputedStyle(a1).marginLeft) + "px"

});

const cr = document.querySelector('.t');
let isnew = false
let cha = 0
let tp = false
let tp1 = false
let tp2 = false
let tp3 = false
let tp4 = false

cr.addEventListener('click', async () => {


    if (cha == 0) {
        const re = document.querySelectorAll('.search,.bu,.bu1')
        re.forEach(re => re.classList.add('re'));
        await new Promise(resolve => setTimeout(resolve, 500))


        re.forEach(re => { re.remove() });

        cr.src = '/sitetemplate/assets/image/otherimg/ko2.png'
        cr.style.marginLeft = -420 + 'px'

        for (let i = 1; i < 7; i++) {

            const im = document.createElement('img')
            im.className = 'im'


            searchBar.appendChild(im);

            im.src = '/sitetemplate/assets/image/otherimg/' + i + 'h.png'
            searchBar.append(im);

            im.style.width = 30 + 'px'
            im.style.height = 30 + 'px'
            if (i == 1) {
                im.style.marginLeft = 80 + 'px';
            }
            else {
                im.style.marginLeft = 30 + 'px'
            }
            setTimeout(() => {
                im.classList.add('show');

            }, i * 150)

            if (i == 1) {
                im.addEventListener('click', () => {
                    if (!tp4) {
                        tp4 = true
                        const menobar = document.createElement('div')
                        const meno = document.createElement('div')

                        menobar.className = 'menobar'
                        meno.className = 'meno'
                        menobar.style.left = (87 * a * i) + 'px'
                        menobar.style.top = (50 * a) + 'px'
                        meno.style.left = (10 * a) + 'px'
                        meno.style.top = (90 * a) + 'px'
                        meno.style.height = (150 * a) + 'px'
                        meno.style.width = (470 * a) + 'px'
                        menobar.style.position = 'fixed'
                        meno.style.position = 'fixed'
                        col.appendChild(menobar)
                        col.appendChild(meno)


                        meno.style.backgroundImage.sr

                        menobar.style.backgroundImage = `url("/sitetemplate/assets/image/otherimg/${i}h.png")`
                        menobar.style.backgroundPosition = 'center'

                        setTimeout(() => {
                            menobar.classList.add('show');
                            meno.classList.add('show');
                        }, 150)


                        meno.style.overflowX = 'auto'
                        meno.style.display = 'flex'


                        meno.style.height = (165 * a) + 'px'
                        const fff = document.createElement('div')
                        const fff1 = document.createElement('img')
                        const fs = document.createElement('img')

                        const fff2 = document.createElement('span')

                        fs.addEventListener('click', () => {
                            fff.remove()
                            fff1.remove()
                            fff2.remove()
                            fs.remove()

                        })

                        fff.classList.add('gks')
                        fff1.classList.add('acss')
                        fff.appendChild(fs)

                        fs.classList.add('fs')




                        fff.style.display = 'flex'
                        fff.style.flexWrap = 'wrap'



                        fs.src = '/sitetemplate/assets/image/otherimg/2h.png'
                        fs.style.borderTopLeftRadius = 14 + 'px'


                        fff.style.flexShrink = 0
                        fff1.src = '/sitetemplate/assets/image/otherimg/men.jpg'
                        fff2.textContent = 'fffffff'
                        fff.style.width = (85 * a) + 'px'
                        fff.style.height = (140 * a) + 'px'
                        fff.style.marginTop = (1 * a) + 'px'
                        fff.style.marginLeft = (4 * a) + 'px'
                        fff1.style.width = (85 * a) + 'px'
                        fff1.style.height = (120 * a) + 'px'
                        fff2.style.marginTop = (2 * a) + 'px'
                        fff2.style.marginLeft = (10 * a) + 'px'
                        fff2.style.fontSize = (14 * a) + 'px'
                        meno.appendChild(fff)
                        fff.appendChild(fff1)
                        fff.appendChild(fff2)

                    }
                    else if (tp4) {
                        tp4 = false
                        const re3 = document.querySelectorAll('.menobar,.meno');
                        re3.forEach(re1 => re1.classList.add('an'));
                        setTimeout(() => {
                            re3.forEach(re => { re.remove() });
                        }, 300)
                    }
                })
            }
            if (i == 2) {
                im.addEventListener('click', () => {
                    if (!tp3) {
                        tp3 = true
                        const menobar = document.createElement('div')
                        const meno = document.createElement('div')

                        menobar.className = 'menobar'
                        meno.className = 'meno'
                        menobar.style.left = (75 * a * i) + 'px'
                        menobar.style.top = (50 * a) + 'px'
                        meno.style.left = (10 * a) + 'px'
                        meno.style.top = (90 * a) + 'px'
                        meno.style.height = (150 * a) + 'px'
                        meno.style.width = (470 * a) + 'px'
                        menobar.style.position = 'fixed'
                        meno.style.position = 'fixed'
                        col.appendChild(menobar)
                        col.appendChild(meno)


                        meno.style.backgroundImage.sr

                        menobar.style.backgroundImage = `url("/sitetemplate/assets/image/otherimg/${i}h.png")`
                        menobar.style.backgroundPosition = 'center'

                        setTimeout(() => {
                            menobar.classList.add('show');
                            meno.classList.add('show');
                        }, 150)



                        meno.style.overflowX = 'auto'
                        meno.style.display = 'flex'
                        meno.style.alignItems = 'center'
                        meno.scrollWidth = 900
                        for (let g = 0; g < 13; g++) {


                            const ff = document.createElement('div')
                            const ff1 = document.createElement('img')
                            const ff2 = document.createElement('span')
                            ff.classList.add('gks')
                            ff1.classList.add('acss')
                            ff2.classList.add('mtns')
                            ff.style.display = 'flex'

                            ff.style.flexShrink = 0
                            ff1.src = '/sitetemplate/assets/image/otherimg/men.jpg'
                            ff2.textContent = 'fffffff'
                            ff.style.width = (120 * a) + 'px'
                            ff.style.height = (130 * a) + 'px'
                            ff.style.marginTop = (1 * a) + 'px'
                            ff.style.marginLeft = (4 * a) + 'px'
                            ff1.style.width = (85 * a) + 'px'
                            ff1.style.height = (130 * a) + 'px'
                            ff2.style.marginTop = (12 * a) + 'px'
                            ff2.style.marginLeft = (5 * a) + 'px'
                            ff2.style.fontSize = (13 * a) + 'px'
                            meno.appendChild(ff)
                            ff.appendChild(ff1)
                            ff.appendChild(ff2)
                        }
                    }
                    else if (tp3) {
                        tp3 = false
                        const re3 = document.querySelectorAll('.menobar,.meno');
                        re3.forEach(re1 => re1.classList.add('an'));
                        setTimeout(() => {
                            re3.forEach(re => { re.remove() });
                        }, 300)
                    }
                })
            }
            if (i == 3) {
                im.addEventListener('click', () => {
                    if (!tp2) {
                        tp2 = true
                        const menobar = document.createElement('div')
                        const meno = document.createElement('div')

                        menobar.className = 'menobar'
                        meno.className = 'meno'
                        menobar.style.left = (70 * a * i) + 'px'
                        menobar.style.top = (50 * a) + 'px'
                        meno.style.left = (10 * a) + 'px'
                        meno.style.top = (90 * a) + 'px'
                        meno.style.height = (150 * a) + 'px'
                        meno.style.width = (470 * a) + 'px'
                        menobar.style.position = 'fixed'
                        meno.style.position = 'fixed'
                        col.appendChild(menobar)
                        col.appendChild(meno)


                        meno.style.backgroundImage.sr

                        menobar.style.backgroundImage = `url("/sitetemplate/assets/image/otherimg/${i}h.png")`
                        menobar.style.backgroundPosition = 'center'

                        setTimeout(() => {
                            menobar.classList.add('show');
                            meno.classList.add('show');
                        }, 150)




                        meno.style.overflowX = 'auto'
                        meno.style.display = 'flex'


                        const fb = document.createElement('img')
                        const fb1 = document.createElement('img')
                        const fb2 = document.createElement('img')

                        meno.style.height = (165 * a) + 'px'
                        const fff = document.createElement('div')
                        const fff1 = document.createElement('img')
                        const fs = document.createElement('img')

                        const fff2 = document.createElement('span')

                        fs.addEventListener('click', () => {
                            fff.remove()
                            fff1.remove()
                            fff2.remove()
                            fs.remove()

                        })

                        fff.classList.add('gks')
                        fff1.classList.add('acss')
                        fs.classList.add('fs')

                        fb.classList.add('fb')
                        fb1.classList.add('fb')
                        fb2.classList.add('fb')
                        fff.appendChild(fs)

                        fb.style.marginTop = (-80 * a) + 'px'
                        fb1.style.marginTop = (0 * a) + 'px'
                        fb2.style.marginTop = (80 * a) + 'px'

                        fb.style.marginLeft = (360 / a) + 'px'
                        fb1.style.marginLeft = (360 / a) + 'px'
                        fb2.style.marginLeft = (360 / a) + 'px'


                        fff.style.display = 'flex'
                        fff.style.flexWrap = 'wrap'



                        fs.src = '/sitetemplate/assets/image/otherimg/2h.png'
                        fs.style.borderTopLeftRadius = 14 + 'px'


                        fff.style.flexShrink = 0
                        fff1.src = '/sitetemplate/assets/image/otherimg/men.jpg'
                        fff2.textContent = 'fffffff'
                        fff.style.width = (85 * a) + 'px'
                        fff.style.height = (140 * a) + 'px'
                        fff.style.marginTop = (1 * a) + 'px'
                        fff.style.marginLeft = (4 * a) + 'px'
                        fff1.style.width = (85 * a) + 'px'
                        fff1.style.height = (120 * a) + 'px'
                        fff2.style.marginTop = (2 * a) + 'px'
                        fff2.style.marginLeft = (10 * a) + 'px'
                        fff2.style.fontSize = (14 * a) + 'px'
                        meno.appendChild(fb)
                        meno.appendChild(fb1)
                        meno.appendChild(fb2)
                        meno.appendChild(fff)

                        fff.appendChild(fff1)
                        fff.appendChild(fff2)

                    }
                    else if (tp2) {
                        tp2 = false
                        const re3 = document.querySelectorAll('.menobar,.meno');
                        re3.forEach(re1 => re1.classList.add('an'));
                        setTimeout(() => {
                            re3.forEach(re => { re.remove() });
                        }, 300)
                    }
                })
            }
            if (i == 4) {
                im.addEventListener('click', () => {
                    if (!tp1) {
                        tp1 = true
                        const menobar = document.createElement('div')
                        const meno = document.createElement('div')

                        menobar.className = 'menobar'
                        meno.className = 'meno'
                        menobar.style.left = (68 * a * i) + 'px'
                        menobar.style.top = (50 * a) + 'px'
                        meno.style.left = (10 * a) + 'px'
                        meno.style.top = (90 * a) + 'px'
                        meno.style.height = (150 * a) + 'px'
                        meno.style.width = (470 * a) + 'px'
                        menobar.style.position = 'fixed'
                        meno.style.position = 'fixed'
                        col.appendChild(menobar)
                        col.appendChild(meno)


                        meno.style.backgroundImage.sr

                        menobar.style.backgroundImage = `url("/sitetemplate/assets/image/otherimg/${i}h.png")`
                        menobar.style.backgroundPosition = 'center'

                        setTimeout(() => {
                            menobar.classList.add('show');
                            meno.classList.add('show');
                        }, 150)




                        const ord = document.createElement('div')
                        const ord1 = document.createElement('img')
                        const ord2 = document.createElement('input')
                        const fb = document.createElement('img')

                        fb.classList.add('fb')
                        ord.classList.add('ord')
                        ord1.classList.add('ord')
                        ord2.classList.add('ord')
                        ord.style.position = 'absolute'
                        meno.appendChild(ord)
                        ord.appendChild(ord1)
                        ord.appendChild(ord2)
                        meno.appendChild(fb)
                        ord.style.marginTop = 10 + 'px'
                        ord.style.display = 'flex'
                        fb.style.marginTop = (100 * a) + 'px'
                        fb.style.marginLeft = (360 / a) + 'px'
                        ord.style.marginLeft = 20 + 'px'
                        ord.style.width = 300 + 'px'
                        ord.style.height = 130 + 'px'
                        ord1.style.width = 90 + 'px'
                        ord1.style.height = 115 + 'px'
                        ord1.style.marginLeft = 10 + 'px'
                        ord1.style.marginTop = 7 + 'px'
                        ord2.style.width = 170 + 'px'
                        ord2.style.height = 115 + 'px'
                        ord2.style.marginLeft = 10 + 'px'
                        ord2.style.marginTop = 5 + 'px'
                        const file = document.createElement('input')
                        file.type = 'file'
                        ord1.addEventListener('click', () => {
                            file.click();
                        })
                        file.addEventListener('change', () => {
                            const f = file.files[0];
                            if (!file) return;

                            const url = URL.createObjectURL(f)
                            ord1.src = url;

                        })
                    }
                    else if (tp1) {
                        tp1 = false
                        const re3 = document.querySelectorAll('.menobar,.meno');
                        re3.forEach(re1 => re1.classList.add('an'));
                        setTimeout(() => {
                            re3.forEach(re => { re.remove() });
                        }, 300)
                    }
                })
            }
            if (i == 5) {
                im.addEventListener('click', () => {
                    if (!tp) {
                        tp = true
                        const menobar = document.createElement('div')
                        const meno = document.createElement('div')

                        menobar.className = 'menobar'
                        meno.className = 'meno'
                        menobar.style.left = (67 * a * i) + 'px'
                        menobar.style.top = (50 * a) + 'px'
                        meno.style.left = (10 * a) + 'px'
                        meno.style.top = (90 * a) + 'px'
                        meno.style.height = (150 * a) + 'px'
                        meno.style.width = (470 * a) + 'px'
                        menobar.style.position = 'fixed'
                        meno.style.position = 'fixed'
                        col.appendChild(menobar)
                        col.appendChild(meno)


                        meno.style.backgroundImage.sr

                        menobar.style.backgroundImage = `url("/sitetemplate/assets/image/otherimg/${i}h.png")`
                        menobar.style.backgroundPosition = 'center'

                        setTimeout(() => {
                            menobar.classList.add('show');
                            meno.classList.add('show');
                        }, 150)


                        const prof = document.createElement('img')
                        const file = document.createElement('input')
                        const name = document.createElement('span')

                        file.type = 'file'
                        prof.addEventListener('click', () => {
                            file.click();
                        })
                        file.addEventListener('change', () => {
                            const f = file.files[0];
                            if (!file) return;

                            const url = URL.createObjectURL(f)
                            prof.src = url;

                        })

                        prof.style.width = (80 * a) + 'px'
                        prof.style.height = (80 * a) + 'px'
                        prof.style.marginTop = (15 * a) + 'px'
                        prof.style.marginLeft = (15 * a) + 'px'
                        name.style.marginTop = (110 * a) + 'px'
                        name.style.marginLeft = (22 * a) + 'px'
                        name.style.fontSize = (14 * a) + 'px'
                        name.textContent = 'exaplename'
                        prof.classList.add('prof')
                        name.style.display = 'inline-block'
                        name.style.position = 'fixed'

                        meno.appendChild(prof)

                        meno.appendChild(name)

                        const gmail = document.createElement('div')
                        const phoag = document.createElement('img')
                        const gt = document.createElement('span')
                        gmail.style.width = (180 * a) + 'px'
                        gmail.style.height = (20 * a) + 'px'
                        gmail.style.marginTop = (15) + 'px'
                        gmail.style.marginLeft = (110 * a) + 'px'
                        gmail.classList.add('prof')

                        phoag.style.height = (15 * a) + 'px'
                        phoag.style.width = (15 * a) + 'px'
                        phoag.style.marginLeft = (10 * a) + 'px'
                        phoag.style.marginTop = (2 * a) + 'px'
                        phoag.src = '/sitetemplate/assets/image/otherimg/1h.png'
                        phoag.style.display = 'inline-block'
                        phoag.style.position = 'fixed'

                        gt.textContent = 'google@gmail.com'
                        gt.style.color = 'white'
                        gt.style.fontSize = (12 * a) + 'px'
                        gt.style.marginLeft = (30 * a) + 'px'
                        gt.style.marginTop = (2 * a) + 'px'

                        gt.style.display = 'inline-block'
                        gt.style.position = 'fixed'


                        meno.appendChild(gmail)

                        gmail.appendChild(gt)
                        gmail.appendChild(phoag)
                        const adress = document.createElement('div')
                        const phoa = document.createElement('img')
                        const ta = document.createElement('span')
                        adress.style.width = (180 * a) + 'px'
                        adress.style.height = (20 * a) + 'px'
                        adress.style.marginTop = (35 * a) + 'px'
                        adress.style.marginLeft = (110 * a) + 'px'
                        adress.classList.add('prof')


                        phoa.style.height = (15 * a) + 'px'
                        phoa.style.width = (15 * a) + 'px'
                        phoa.style.marginLeft = (10 * a) + 'px'
                        phoa.style.marginTop = (2 * a) + 'px'
                        phoa.src = '/sitetemplate/assets/image/otherimg/1h.png'
                        phoa.style.display = 'inline-block'
                        phoa.style.position = 'fixed'

                        ta.textContent = '---flowstreta-landan-emereka'
                        gmail.style.overflow = 'auto'
                        ta.style.color = 'white'
                        ta.style.fontSize = (12 * a) + 'px'
                        ta.style.marginLeft = (30 * a) + 'px'
                        ta.style.marginTop = (3 * a) + 'px'

                        ta.style.display = 'inline-block'
                        ta.style.position = 'fixed'


                        meno.appendChild(adress)

                        adress.appendChild(phoa)
                        adress.appendChild(ta)

                        const addf = document.createElement('div')
                        const addff = document.createElement('div')
                        const phof = document.createElement('img')
                        const tad = document.createElement('span')
                        addf.style.display = 'flex'
                        addf.style.flexWrap = 'wrap'
                        addff.style.position = 'relative'

                        addff.addEventListener('click', () => {
                            if (addf.children.length <= 11) {
                                const ff = document.createElement('div')
                                const ff1 = document.createElement('img')
                                const ff2 = document.createElement('span')
                                ff.classList.add('prof')
                                ff.style.position = 'relative'
                                ff.style.background = `rgba(${2}37, ${1}37, ${1}37, 0.655)`

                                ff.style.width = (80 * a) + 'px'
                                ff.style.height = (20 * a) + 'px'
                                ff.style.marginTop = (4 * a) + 'px'
                                ff.style.marginLeft = (4 * a) + 'px'

                                addf.appendChild(ff)
                                ff.appendChild(ff1)
                                ff.appendChild(ff2)
                            }
                        })
                        addf.style.width = (340 * a) + 'px'
                        addf.style.height = (85 * a) + 'px'
                        addf.style.marginTop = (60 * a) + 'px'
                        addf.style.marginLeft = (110 * a) + 'px'
                        addf.style.position = 'fixed'
                        addff.classList.add('prof')

                        addff.style.width = (70 * a) + 'px'
                        addff.style.height = (20 * a) + 'px'
                        addff.style.marginTop = (4 * a) + 'px'
                        addff.style.marginLeft = (5 * a) + 'px'


                        meno.appendChild(addf)
                        addf.appendChild(addff)
                        addff.appendChild(phof)
                        addff.appendChild(tad)

                        const coment = document.createElement('div')
                        const phoc = document.createElement('img')
                        const tc = document.createElement('span')
                        coment.style.width = (80 * a) + 'px'
                        coment.style.height = (45 * a) + 'px'
                        coment.style.marginTop = (10 * a) + 'px'
                        coment.style.marginLeft = (295 * a) + 'px'
                        coment.classList.add('prof')
                        phoc.classList.add('prof')
                        tc.classList.add('prof')

                        meno.appendChild(coment)

                        coment.appendChild(phoc)
                        coment.appendChild(tc)

                        const me = document.createElement('div')
                        const phom = document.createElement('img')
                        const tm = document.createElement('span')
                        me.style.width = (80 * a) + 'px'
                        me.style.height = (45 * a) + 'px'
                        me.style.marginTop = (10 * a) + 'px'
                        me.style.marginLeft = (380 * a) + 'px'
                        me.classList.add('prof')
                        phom.classList.add('prof')
                        tm.classList.add('prof')

                        meno.appendChild(me)
                        me.appendChild(phom)
                        me.appendChild(tm)

                    }
                    else if (tp) {
                        tp = false
                        const re3 = document.querySelectorAll('.menobar,.meno');
                        re3.forEach(re1 => re1.classList.add('an'));
                        setTimeout(() => {
                            re3.forEach(re => { re.remove() });
                        }, 300)
                    }
                })
            }


            cha = 1
        }
    }

    else if (cha == 1) {
        cha = 2
        cr.src = '/sitetemplate/assets/image/otherimg/ko1.png'
        cr.style.marginLeft = -420 + 'px'

        const bar = document.createElement('div')
        bar.className = 'bar'
        bar.style.height = window.innerHeight - 50 + 'px'
        col.appendChild(bar)

        for (let i = 0; i < 5; i++) {
            const menobar = document.createElement('div')
            const meno = document.createElement('div')

            menobar.className = 'menobar'
            meno.className = 'meno'

            col.appendChild(menobar)
            col.appendChild(meno)

            bar.appendChild(menobar)
            bar.appendChild(meno)
            bar.style.width = (520 * a) + 'px'
            meno.style.backgroundImage.sr

            menobar.style.backgroundImage = `url("/sitetemplate/assets/image/otherimg/${i + 1}h.png")`
            menobar.style.backgroundPosition = 'center'

            setTimeout(() => {
                menobar.classList.add('show');
                meno.classList.add('show');
            }, i * 350)



            if (i == 0) {
                const ord = document.createElement('div')
                const ord1 = document.createElement('img')
                const ord2 = document.createElement('input')
                const fb = document.createElement('img')

                fb.classList.add('fb')
                ord.classList.add('ord')
                ord1.classList.add('ord')
                ord2.classList.add('ord')
                ord.style.position = 'absolute'
                meno.appendChild(ord)
                ord.appendChild(ord1)
                ord.appendChild(ord2)
                meno.appendChild(fb)
                ord.style.marginTop = 10 + 'px'
                ord.style.display = 'flex'
                fb.style.marginTop = (100 * a) + 'px'
                fb.style.marginLeft = (360 / a) + 'px'
                ord.style.marginLeft = 20 + 'px'
                ord.style.width = 300 + 'px'
                ord.style.height = 130 + 'px'
                ord1.style.width = 90 + 'px'
                ord1.style.height = 115 + 'px'
                ord1.style.marginLeft = 10 + 'px'
                ord1.style.marginTop = 7 + 'px'
                ord2.style.width = 170 + 'px'
                ord2.style.height = 115 + 'px'
                ord2.style.marginLeft = 10 + 'px'
                ord2.style.marginTop = 5 + 'px'
                const file = document.createElement('input')
                file.type = 'file'
                ord1.addEventListener('click', () => {
                    file.click();
                })
                file.addEventListener('change', () => {
                    const f = file.files[0];
                    if (!file) return;

                    const url = URL.createObjectURL(f)
                    ord1.src = url;

                })

            }
            if (i == 1) {
                meno.style.overflowX = 'auto'
                meno.style.display = 'flex'


                const fb = document.createElement('img')
                const fb1 = document.createElement('img')
                const fb2 = document.createElement('img')

                meno.style.height = (165 * a) + 'px'
                const fff = document.createElement('div')
                const fff1 = document.createElement('img')
                const fs = document.createElement('img')

                const fff2 = document.createElement('span')

                fs.addEventListener('click', () => {
                    fff.remove()
                    fff1.remove()
                    fff2.remove()
                    fs.remove()

                })

                fff.classList.add('gks')
                fff1.classList.add('acss')
                fs.classList.add('fs')

                fb.classList.add('fb')
                fb1.classList.add('fb')
                fb2.classList.add('fb')
                fff.appendChild(fs)

                fb.style.marginTop = (-80 * a) + 'px'
                fb1.style.marginTop = (0 * a) + 'px'
                fb2.style.marginTop = (80 * a) + 'px'

                fb.style.marginLeft = (360 / a) + 'px'
                fb1.style.marginLeft = (360 / a) + 'px'
                fb2.style.marginLeft = (360 / a) + 'px'


                fff.style.display = 'flex'
                fff.style.flexWrap = 'wrap'



                fs.src = '/sitetemplate/assets/image/otherimg/2h.png'
                fs.style.borderTopLeftRadius = 14 + 'px'


                fff.style.flexShrink = 0
                fff1.src = '/sitetemplate/assets/image/otherimg/men.jpg'
                fff2.textContent = 'fffffff'
                fff.style.width = (85 * a) + 'px'
                fff.style.height = (140 * a) + 'px'
                fff.style.marginTop = (1 * a) + 'px'
                fff.style.marginLeft = (4 * a) + 'px'
                fff1.style.width = (85 * a) + 'px'
                fff1.style.height = (120 * a) + 'px'
                fff2.style.marginTop = (2 * a) + 'px'
                fff2.style.marginLeft = (10 * a) + 'px'
                fff2.style.fontSize = (14 * a) + 'px'
                meno.appendChild(fb)
                meno.appendChild(fb1)
                meno.appendChild(fb2)
                meno.appendChild(fff)

                fff.appendChild(fff1)
                fff.appendChild(fff2)
            }
            if (i == 2) {
                meno.style.overflowX = 'auto'
                meno.style.display = 'flex'


                meno.style.height = (165 * a) + 'px'
                const fff = document.createElement('div')
                const fff1 = document.createElement('img')
                const fs = document.createElement('img')

                const fff2 = document.createElement('span')

                fs.addEventListener('click', () => {
                    fff.remove()
                    fff1.remove()
                    fff2.remove()
                    fs.remove()

                })

                fff.classList.add('gks')
                fff1.classList.add('acss')
                fff.appendChild(fs)

                fs.classList.add('fs')




                fff.style.display = 'flex'
                fff.style.flexWrap = 'wrap'



                fs.src = '/sitetemplate/assets/image/otherimg/2h.png'
                fs.style.borderTopLeftRadius = 14 + 'px'


                fff.style.flexShrink = 0
                fff1.src = '/sitetemplate/assets/image/otherimg/men.jpg'
                fff2.textContent = 'fffffff'
                fff.style.width = (85 * a) + 'px'
                fff.style.height = (140 * a) + 'px'
                fff.style.marginTop = (1 * a) + 'px'
                fff.style.marginLeft = (4 * a) + 'px'
                fff1.style.width = (85 * a) + 'px'
                fff1.style.height = (120 * a) + 'px'
                fff2.style.marginTop = (2 * a) + 'px'
                fff2.style.marginLeft = (10 * a) + 'px'
                fff2.style.fontSize = (14 * a) + 'px'
                meno.appendChild(fff)
                fff.appendChild(fff1)
                fff.appendChild(fff2)
            }
            if (i == 3) {
                meno.style.overflowX = 'auto'
                meno.style.display = 'flex'
                meno.style.alignItems = 'center'
                meno.scrollWidth = 900
                for (let g = 0; g < 13; g++) {


                    const ff = document.createElement('div')
                    const ff1 = document.createElement('img')
                    const ff2 = document.createElement('span')
                    ff.classList.add('gks')
                    ff1.classList.add('acss')
                    ff2.classList.add('mtns')
                    ff.style.display = 'flex'

                    ff.style.flexShrink = 0
                    ff1.src = '/sitetemplate/assets/image/otherimg/men.jpg'
                    ff2.textContent = 'fffffff'
                    ff.style.width = (120 * a) + 'px'
                    ff.style.height = (130 * a) + 'px'
                    ff.style.marginTop = (1 * a) + 'px'
                    ff.style.marginLeft = (4 * a) + 'px'
                    ff1.style.width = (85 * a) + 'px'
                    ff1.style.height = (130 * a) + 'px'
                    ff2.style.marginTop = (12 * a) + 'px'
                    ff2.style.marginLeft = (5 * a) + 'px'
                    ff2.style.fontSize = (13 * a) + 'px'
                    meno.appendChild(ff)
                    ff.appendChild(ff1)
                    ff.appendChild(ff2)

                }
            }
            if (i == 4) {

                const prof = document.createElement('img')

                const name = document.createElement('span')
                const file = document.createElement('input')
                file.type = 'file'
                prof.addEventListener('click', () => {
                    file.click();
                })
                file.addEventListener('change', () => {
                    const f = file.files[0];
                    if (!file) return;

                    const url = URL.createObjectURL(f)
                    prof.src = url;

                })

                prof.style.width = (80 * a) + 'px'
                prof.style.height = (80 * a) + 'px'
                prof.style.marginTop = (15 * a) + 'px'
                prof.style.marginLeft = (15 * a) + 'px'
                name.style.marginTop = (110 * a) + 'px'
                name.style.marginLeft = (22 * a) + 'px'
                name.style.fontSize = (14 * a) + 'px'
                name.textContent = 'exaplename'
                prof.classList.add('prof')
                name.style.display = 'inline-block'
                name.style.position = 'fixed'

                meno.appendChild(prof)

                meno.appendChild(name)

                const gmail = document.createElement('div')
                const phoag = document.createElement('img')
                const gt = document.createElement('span')
                gmail.style.width = (180 * a) + 'px'
                gmail.style.height = (20 * a) + 'px'
                gmail.style.marginTop = (15) + 'px'
                gmail.style.marginLeft = (110 * a) + 'px'
                gmail.classList.add('prof')

                phoag.style.height = (15 * a) + 'px'
                phoag.style.width = (15 * a) + 'px'
                phoag.style.marginLeft = (10 * a) + 'px'
                phoag.style.marginTop = (2 * a) + 'px'
                phoag.src = '/sitetemplate/assets/image/otherimg/1h.png'
                phoag.style.display = 'inline-block'
                phoag.style.position = 'fixed'

                gt.textContent = 'google@gmail.com'
                gt.style.color = 'white'
                gt.style.fontSize = (12 * a) + 'px'
                gt.style.marginLeft = (30 * a) + 'px'
                gt.style.marginTop = (2 * a) + 'px'

                gt.style.display = 'inline-block'
                gt.style.position = 'fixed'


                meno.appendChild(gmail)

                gmail.appendChild(gt)
                gmail.appendChild(phoag)
                const adress = document.createElement('div')
                const phoa = document.createElement('img')
                const ta = document.createElement('span')
                adress.style.width = (180 * a) + 'px'
                adress.style.height = (20 * a) + 'px'
                adress.style.marginTop = (35 * a) + 'px'
                adress.style.marginLeft = (110 * a) + 'px'
                adress.classList.add('prof')


                phoa.style.height = (15 * a) + 'px'
                phoa.style.width = (15 * a) + 'px'
                phoa.style.marginLeft = (10 * a) + 'px'
                phoa.style.marginTop = (2 * a) + 'px'
                phoa.src = '/sitetemplate/assets/image/otherimg/1h.png'
                phoa.style.display = 'inline-block'
                phoa.style.position = 'fixed'

                ta.textContent = '---flowstreta-landan-emereka'
                gmail.style.overflow = 'auto'
                ta.style.color = 'white'
                ta.style.fontSize = (12 * a) + 'px'
                ta.style.marginLeft = (30 * a) + 'px'
                ta.style.marginTop = (3 * a) + 'px'

                ta.style.display = 'inline-block'
                ta.style.position = 'fixed'


                meno.appendChild(adress)

                adress.appendChild(phoa)
                adress.appendChild(ta)

                const addf = document.createElement('div')
                const addff = document.createElement('div')
                const phof = document.createElement('img')
                const tad = document.createElement('span')
                addf.style.display = 'flex'
                addf.style.flexWrap = 'wrap'
                addff.style.position = 'relative'

                addff.addEventListener('click', () => {
                    if (addf.children.length <= 11) {
                        const ff = document.createElement('div')
                        const ff1 = document.createElement('img')
                        const ff2 = document.createElement('span')
                        ff.classList.add('prof')
                        ff.style.position = 'relative'
                        ff.style.background = `rgba(${2}37, ${1}37, ${1}37, 0.655)`

                        ff.style.width = (80 * a) + 'px'
                        ff.style.height = (20 * a) + 'px'
                        ff.style.marginTop = (4 * a) + 'px'
                        ff.style.marginLeft = (4 * a) + 'px'

                        addf.appendChild(ff)
                        ff.appendChild(ff1)
                        ff.appendChild(ff2)
                    }
                })
                addf.style.width = (340 * a) + 'px'
                addf.style.height = (85 * a) + 'px'
                addf.style.marginTop = (60 * a) + 'px'
                addf.style.marginLeft = (110 * a) + 'px'
                addf.style.position = 'fixed'
                addff.classList.add('prof')

                addff.style.width = (70 * a) + 'px'
                addff.style.height = (20 * a) + 'px'
                addff.style.marginTop = (4 * a) + 'px'
                addff.style.marginLeft = (5 * a) + 'px'


                meno.appendChild(addf)
                addf.appendChild(addff)
                addff.appendChild(phof)
                addff.appendChild(tad)

                const coment = document.createElement('div')
                const phoc = document.createElement('img')
                const tc = document.createElement('span')
                coment.style.width = (80 * a) + 'px'
                coment.style.height = (45 * a) + 'px'
                coment.style.marginTop = (10 * a) + 'px'
                coment.style.marginLeft = (295 * a) + 'px'
                coment.classList.add('prof')
                phoc.classList.add('prof')
                tc.classList.add('prof')

                meno.appendChild(coment)

                coment.appendChild(phoc)
                coment.appendChild(tc)

                const me = document.createElement('div')
                const phom = document.createElement('img')
                const tm = document.createElement('span')
                me.style.width = (80 * a) + 'px'
                me.style.height = (45 * a) + 'px'
                me.style.marginTop = (10 * a) + 'px'
                me.style.marginLeft = (380 * a) + 'px'
                me.classList.add('prof')
                phom.classList.add('prof')
                tm.classList.add('prof')

                meno.appendChild(me)
                me.appendChild(phom)
                me.appendChild(tm)

            }




            if (i == 0) {
                menobar.style.marginTop = (60 * a) + 'px'

                menobar.style.marginLeft = (60 * a) + 'px'

                meno.style.height = (150 * a) + 'px'
                meno.style.width = (470 * a) + 'px'

            }
            else {
                menobar.style.marginTop = (5 * a) + 'px'

                menobar.style.marginLeft = 60 + (a * i * 80) + 'px'

                meno.style.height = (150 * a) + 'px'
                meno.style.width = (470 * a) + 'px'
            }
        }



    }
    else if (cha == 2) {
        cr.src = '/sitetemplate/assets/image/otherimg/ko.png'

        const re3 = document.querySelectorAll('.menobar,.meno,.bar');
        re3.forEach(re1 => re1.classList.add('an'));
        await new Promise(resolve => setTimeout(resolve, 550))

        re3.forEach(re => { re.remove() });

        const re2 = document.querySelectorAll('.im');
        re2.forEach(re1 => re1.classList.add('an'));
        await new Promise(resolve => setTimeout(resolve, 550))

        re2.forEach(re => { re.remove() });

        const search = document.createElement('input')
        const bo = document.createElement('button')
        const bo1 = document.createElement('button')


        search.className = 'search'
        bo.className = 'bu'
        bo1.className = 'bu1'

        setTimeout(() => {
            search.classList.add('show');
            bo.classList.add('show');
            bo1.classList.add('show');

            bo1.addEventListener("click", (ev) => {
                bo.style.marginLeft = 365 + "px"
                bo.style.zIndex = 0
                bo.style.borderTopLeftRadius = "0px"
                bo.style.borderBottomLeftRadius = "0px"
                bo.style.borderLeft = "none";
                bo.style.width = 50 + "px";
                bo1.style.zIndex = 1
                bo1.style.marginLeft = 285 + "px"
                bo1.style.width = 60 + "px"
                bo1.style.borderTopLeftRadius = "24px"
                bo1.style.borderBottomLeftRadius = "24px"
                search.placeholder = 'AI'
                search.classList.add('ai')
            })
            bo.addEventListener("click", () => {
                search.classList.remove('ai')
                bo1.style.marginLeft = 370 + "px"
                bo1.style.zIndex = 0
                bo1.style.borderTopLeftRadius = "0px"
                bo1.style.borderBottomLeftRadius = "0px"
                bo1.style.borderLeft = "none";
                bo1.style.width = 70 + "px";
                bo.style.zIndex = 1
                bo.style.marginLeft = 299 + "px"
                bo.style.width = 40 + "px"
                bo.style.borderTopLeftRadius = "24px"
                bo.style.borderBottomLeftRadius = "24px"
                search.placeholder = 'search'
            })

        }, 350)



        search.placeholder = 'search'
        bo.textContent = '🔍'
        bo1.textContent = '✨AI '

        searchBar.appendChild(search)
        searchBar.appendChild(bo)
        searchBar.appendChild(bo1)


        cha = 0
    }
})

const search1 = document.querySelector('.search');

bo1.addEventListener("click", (ev) => {
    search1.classList.add('ai')
    bo.style.marginLeft = 365 + "px"
    bo.style.zIndex = 0
    bo.style.borderTopLeftRadius = "0px"
    bo.style.borderBottomLeftRadius = "0px"
    bo.style.borderLeft = "none";
    bo.style.width = 50 + "px";
    bo1.style.zIndex = 1
    bo1.style.marginLeft = 285 + "px"
    bo1.style.width = 60 + "px"
    bo1.style.borderTopLeftRadius = "24px"
    bo1.style.borderBottomLeftRadius = "24px"
    search1.placeholder = 'AI'
    search1.classList.add('ai')
})
bo.addEventListener("click", () => {
    search1.classList.remove('ai')
    bo1.style.marginLeft = 370 + "px"
    bo1.style.zIndex = 0
    bo1.style.borderTopLeftRadius = "0px"
    bo1.style.borderBottomLeftRadius = "0px"
    bo1.style.borderLeft = "none";
    bo1.style.width = 70 + "px";
    bo.style.zIndex = 1
    bo.style.marginLeft = 305 + "px"
    bo.style.width = 40 + "px"
    bo.style.borderTopLeftRadius = "24px"
    bo.style.borderBottomLeftRadius = "24px"
    search1.placeholder = 'search'
})


document.addEventListener('click', function (eve) {

    const col = document.querySelector('.col')
    const tel = eve.target;

    if (tel.classList.contains('mah')) {
        const ecl = tel.className;
        const ped = tel.parentElement;
        const rect = tel.getBoundingClientRect();
        const sty = window.getComputedStyle(tel);

        const chi = document.createElement('div');
        col.appendChild(chi)


        for (let i = 1; i < 5; i++) {
            const chi1 = document.createElement('img');
            chi.append(chi1);
            chi1.src = `/sitetemplate/assets/image/otherimg/${i}h.png`
            chi1.style.width = 22 + 'px'
            chi1.style.height = 22 + 'px'
            chi1.style.marginLeft = 11 + 'px'
            chi1.style.marginTop = 8 + 'px'
            chi1.classList.add('chi')

            chi1.addEventListener('click', (e1) => {
                if (i == 3) {




                    let element = document.querySelector('.pomog')
                    if (!element) {
                        let est = false

                        const mog = document.createElement('div')
                        const mogbtn = document.createElement('div')
                        const mogbtnca = document.createElement('div')
                        col.appendChild(mog)
                        mog.appendChild(mogbtn)
                        mog.appendChild(mogbtnca)

                        mog.classList.add('mog')
                        mogbtn.classList.add('mogbtn')
                        mogbtnca.classList.add('mogbtn')
                        mogbtn.style.backgroundImage = 'url("/sitetemplate/assets/image/otherimg/1h.png")'
                        mogbtnca.style.backgroundImage = 'url("/sitetemplate/assets/image/otherimg/1h.png")'
                        mogbtnca.style.marginLeft = 70 + 'px'


                        mogbtnca.addEventListener('click', () => {
                            const ham = document.querySelectorAll('.mog,.mogbtn,.mogbtnca,.pomog')
                            ham.forEach(e => {
                                e.classList.add('r');
                                setTimeout(() => {
                                    e.remove();
                                }, 350)
                            })
                        })

                        let mo = false
                        mogbtn.addEventListener('click', () => {

                            if (mo) {
                                mo = false

                                mogbtn.style.marginTop = 130 + 'px'
                                mogbtnca.style.marginTop = 130 + 'px'
                                mogbtn.style.marginLeft = 25 + 'px'
                                mogbtnca.style.marginLeft = 70 + 'px'
                                mogbtn.style.width = 35 + 'px'
                                mogbtn.style.height = 30 + 'px'
                                mogbtnca.style.width = 35 + 'px'
                                mogbtnca.style.height = 30 + 'px'
                                mog.style.width = 150 + 'px'
                                mog.style.marginLeft = window.innerWidth - 150 + 'px'

                                mog.style.height = 170 + 'px'
                                mog.style.top = 0
                                mog.style.marginTop = 0

                                mog.style.borderRadius = 0 + 'px'
                                mog.style.borderBottomLeftRadius = 24 + 'px'

                                const pomog = document.querySelectorAll('.pomog')
                                let ii = 0
                                pomog.forEach(pomog => {

                                    ii += 1
                                    pomog.style.width = 80 + 'px'
                                    pomog.style.height = 112 + 'px'
                                    pomog.style.marginLeft = (15 * ii) + 'px'

                                    pomog.style.position = 'absolute'
                                })


                                console.log('kk')
                            } else {
                                mo = true
                                mogbtn.style.marginTop = (window.innerHeight * 0.72) + 'px'
                                mogbtnca.style.marginTop = (window.innerHeight * 0.72) + 'px'
                                mogbtnca.style.marginLeft = (window.innerHeight * 0.12) + 'px'
                                mogbtn.style.width = (window.innerHeight * 0.07) + 'px'
                                mogbtn.style.height = (window.innerHeight * 0.07) + 'px'
                                mogbtnca.style.width = (window.innerHeight * 0.07) + 'px'
                                mogbtnca.style.height = (window.innerHeight * 0.07) + 'px'

                                mog.style.width = window.innerHeight * 0.533 + 'px'
                                mog.style.height = window.innerHeight * 0.8 + 'px'
                                mog.style.marginTop = window.innerHeight * 0.10 + 'px'
                                mog.style.marginLeft = (window.innerWidth * 0.5) - ((window.innerHeight * 0.533) * 0.5) + 'px'
                                mog.style.borderRadius = 18 + 'px'


                                const pomog = document.querySelectorAll('.pomog')
                                pomog.forEach(pomog => {

                                    pomog.style.width = window.innerWidth * 0.04 + 'px'
                                    pomog.style.height = window.innerHeight * 0.04 + 'px'
                                    pomog.style.position = 'relative'
                                    pomog.classList.add('po')
                                    pomog.style.width = window.innerHeight * 0.234 + 'px'
                                    pomog.style.height = window.innerHeight * 0.336 + 'px'
                                    pomog.style.marginLeft = window.innerHeight * 0.02 + 'px'

                                    console.log(window.innerWidth)
                                })

                            }
                        })


                        for (let p = 1; p <= 4; p++) {
                            const pomog = document.createElement('img')
                            pomog.classList.add('pomog')

                          

                            mog.appendChild(pomog)
                            pomog.style.marginLeft = (15 * p) + 'px'
                            pomog.style.zIndex = 998 - p




                            if (!est) {
                                if (!pomog.getAttribute('src')) {
                                    pomog.src = `/${tel.src.split('/').pop()}`
                                    est = true
                                }
                            }

                        }
                    }
                    else {
                        const el = document.querySelectorAll('.pomog')
                        let yn = false
                        el.forEach(element => {
                            if (!element.getAttribute('src')) {
                                if (!yn) {
                                    yn = true
                                   
                                    element.src = `/${tel.src.split('/').pop()}`
                                }
                            }
                        });
                    }




                }
            })


        }



        chi.classList.add('jazire')
        chi.style.marginLeft = eve.clientX + 'px'
        chi.style.marginTop = ((((window.scrollY) - col.scrollHeight) + 750 + (eve.clientY - window.innerHeight) - 90)) + 'px'

        col.appendChild(chi);
        setTimeout(() => {
            chi.classList.add('show');

        }, 0)

        setTimeout(() => {
            chi.classList.add('re');
            setTimeout(() => {
                chi.remove();
            }, 350)
        }, 3350)

  //      console.log(`${chi.style.marginTop} ,${window.scrollY},${col.scrollHeight},${eve.clientY},${window.innerHeight},${a}`)
    }
}
        )

