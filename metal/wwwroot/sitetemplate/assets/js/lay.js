
                  const t = document.querySelector(`.t`);
                  const serinp = document.querySelector(`.serinp`);
                  const sop = document.querySelector(`.sop`);
                  const sop1 = document.querySelector(`.sop1`);
                  const searchBar = document.querySelector(".search-bar");
                  const search1 = document.querySelector(".search");
                  const bo = document.querySelector(".bu");
                  const bo1 = document.querySelector(".bu1");
                  const col = document.querySelector(".col");
                  const jazire = document.querySelector(".jazire");
                  const mogg = document.querySelector(".mog");
                  const mogpan = document.querySelector(".mogpan");
                  const moga = document.querySelector(".moga");
                  const amog = document.querySelector(".amog");
                  const slike = document.querySelector(".slike");
                  const ilike = document.querySelector(".ilike");
                  const like = document.querySelector(".like");



    const khodecore = document.querySelector(".khodecore");
    const body = document.querySelector(".body");
 //   const col = document.querySelector(".col0");
    const parts = document.querySelector(".parts");
    //
    const body2 = document.querySelector(".body2");
    const addadr = document.querySelector(".addadr");
    const addpos = document.querySelector(".addpos");
    const adrbt = document.querySelector(".adrbt");
    const posbt = document.querySelector(".posbt");

    const adrin = document.querySelector(".adrin");
    const posin = document.querySelector(".posin");

    const adrse = document.querySelector(".adrse");
    const posse = document.querySelector(".posse");

    const body3 = document.querySelector(".body3");
      //      const add = document.querySelector(".add");
            const body1 = document.querySelector(".body1");
            const f12 = document.querySelector(".f12");
      //      const favrate = document.querySelector(".favrate");


const val = document.querySelectorAll(".val");
const val1 = document.querySelectorAll(".val1");
const shop = document.querySelector(".shop");
const input = document.querySelectorAll(".many");
const btnPlus = document.querySelectorAll(".quantity-up");
const btnMinus = document.querySelectorAll(".quantity-down");    


        const inf = 0;
        var cha = 0;

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



////////////////


async function uploadImage(Formdata) {


    try {
        const response = await fetch('/Profile/compprofimg', { // آدرس API خود را اینجا بگذارید
            method: 'POST',
            body: Formdata
        });

        if (response.ok) {
            alert("آپلود با موفقیت انجام شد!");
        } else {
            alert("خطا در آپلود.");
        }
    } catch (error) {
        console.error("Error:", error);
    }
}


/////////////////////////////////////

function loading(pel) {
    console.log('loding')
    const l = document.createElement('span')
    l.textContent = "Loading...."
    l.classList.add('loading')
    pel.appendChild(l) 
}

/////////////////////////////////////
const logr = document.querySelector(".logr")
var user = false
if (logr != null) {
    user = true
}
////////////////////////////////

      function dbclick(loc) {
        window.location.replace(loc);
      }

      /////////////////////////////////////



    adrse.addEventListener('change',() => {
        if(adrse.value != ""){
        adrin.disabled = true
        }else{
        adrin.disabled = false
        }
    })
    posse.addEventListener('change',() => {
        if(posse.value != ""){
        posin.disabled = true
        }else{
        posin.disabled = false
        }
    })
    adrse.value = ""
    posse.value = ""
    function pcomp(seli = addpos){
   // seli.addEventListener("click", () => {
      body3.style.display = "flex";
  //  });        
    }
    function pcompadr(seli = addadr){
   // seli.addEventListener("click", () => {
      body2.style.display = "flex";
   // });        
    }
    async function pcomp1(seli = adrbt){
  //  seli.addEventListener("click", () => {
      body2.style.display = "none";
  //  });      
    if(adrse.value != null){
                var r = await fetch(`/Profile/compprof?adrid=${adrse.value}`);
    }else{
    if(adrin.value != null){
                var r = await fetch(`/Profile/compprof?adr=${adrin.value}`);
    }
   }
    }
    async function pcompadr1(seli = posbt){
  //  seli.addEventListener("click", () => {
      body3.style.display = "none";
  //  });
      if(posse.value != 0){
                var r = await fetch(`/Profile/compprof?adrid=${posse.value}`);
    }else{
      if(posin.value != null){
          console.log(posin.value)
       var r = await fetch(`/Profile/compprof?post=${posin.value}`);
      }
    }
    }

//////////////////
document.addEventListener('DOMContentLoaded', () => {
    Array.from(input).forEach((in1, ind) => {
        in1.addEventListener('change', () => {
            let min = parseInt(in1.min) || 0;
            let max = parseInt(in1.max) || Infinity;
            let val = parseInt(in1.value) || min;

            if (val < min) in1.value = min;
            if (val > max) in1.value = max;

        });

        btnPlus[ind].addEventListener('click', () => {
            input[ind].stepUp();
            input[ind].dispatchEvent(new Event('change', { bubbles: true }));
        });

        // کاهش مقدار
        btnMinus[ind].addEventListener('click', () => {
            input[ind].stepDown();
            input[ind].dispatchEvent(new Event('change', { bubbles: true }));
        });

        // جلوگیری از تایپ دستی مقادیر کمتر از min یا بیشتر از max
    });
});
function AddCount(CartItemId) {
    //   window.location.replace('/cart/add?CartItemId=' + CartItemId);
    var fet = fetch('/cart/add?CartItemId=' + CartItemId)
}

function lowCount(CartItemId) {
    //   window.location.replace('/cart/LowOff?CartItemId=' + CartItemId);
    var fet1 = fetch('/cart/LowOff?CartItemId=' + CartItemId)
}

/////////////////
            async function fa(f) {

                var r = await fetch(`/Profile/favprof`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(f)
                })

                console.log(r)
            }


            function selfa(seli) {
                seli.addEventListener("click", () => {
                    body1.style.display = "flex";
                });
            }

            function selfa1(seli, selicl) {
                const selectf1 = document.querySelector(".selectf");
                Array.from(seli.children).forEach((ff, ff1) => {
                    if (ff1 == 0) {
                    } else {
                        ff.remove();
                    }
                });
                const jv = [];
                Array.from(selectf1.children).forEach((f) => {
                    f.classList.forEach((c) => {
                        console.log(c);
                        if (c == "ccc") {
                            const fbotton = document.createElement("button");
                            fbotton.classList.add(`${selicl}`);
                            seli.appendChild(fbotton);
                            fbotton.innerHTML = f.textContent;
                            f.classList.remove("ccc");
                            f.children[1].remove();
                            jv.push(f.children[0].textContent)
                        }
                    });

                    body1.style.display = "none";
                });
                fa(jv);
            }

            f12.addEventListener("click", () => {
                body1.style.display = "none";
            });

            const selectf = document.querySelector(".selectf");

            Array.from(selectf.children).forEach((iner, inde) => {
                var hh = `f${inde}`;
                if ("f12" != iner.classList[1]) {
                    iner.addEventListener("click", () => {
                        if (hh == `f${inde}`) {
                            hh = `t${inde}`;
                            const cimg = document.createElement("img");
                            cimg.classList.add("cimg");
                            iner.classList.add("ccc");
                            iner.appendChild(cimg);
                        } else {
                            hh = `f${inde}`;
                            iner.removeChild(iner.children[1]);
                        }
                    });

                }
            });



                  ///////////////////////////////////////

                  function tf() {
                    if (window.innerWidth <= 900) {
                      if (sop1.style.display != "flex") {
                        serinp.style.display = "none";
                        sop1.style.display = "flex";
                        sop.style.width = 95 + "%";
                      } else {
                        serinp.style.display = "flex";
                        sop1.style.display = "none";
                        sop.style.width = 15 + "%";
                      }
                    }
                  }

                 function bar(ll) {
                    const op = document.querySelectorAll(`.meno-${ll}`);
                    const barr = document.querySelector(".bar");
                    barr.classList.remove("displaynone");
                    console.log(barr.style.display);

                     Array.from(op).forEach(async (p, n) => {
                         if (p.classList.contains("displaynone")) {
                             p.classList.remove("displaynone");
                             console.log(p.style.display);
                         } else {
                             if (barr.children.length == 0) {
                                 barr.classList.add("displaynone")
                             }
                             p.classList.add("displaynone");
                             console.log(p.style.display);
                         }

                        if (ll == "op1" && n == 1 ) {
                            loading(p);

                            const resp1 = await fetch(`/Profile/mprof?us=${logr.dataset.v}`)
                        //    window.location.href = resp1.url
                          console.log(resp1.url)
                          const ht = await resp1.text();
                            p.innerHTML = ht


                          const file = await document.querySelector(".profin");
                          const prof = await document.querySelector(".prof");
                          const addff = await document.querySelector(".addff");
                          const addf = await document.querySelector(".addf");

                          await selfa(addff);
                          await f12.addEventListener("click", () => {
                                   selfa1(addf, "addff");
                               });

                              //          const file = document.querySelector(".profin");
                             //           const prof = document.querySelector(".prof");
                            //            file.type = "file";
                            //            prof.addEventListener("click", () => {
                            //                file.click();
                            //            });
                            //            file.addEventListener("change", () => {
                           //                 const f = file.files[0];
                           //                 if (!file) return;

                           ///                 const url = URL.createObjectURL(f);
                           //                 prof.src = url;
                          //              });

                        }
                        if (ll == "op2" && n == 1 && p.children.length == 0) {
                            loading(p);
                            const sabad1 = await fetch("/like/getlike")
                            window.location.href = sabad1.url
                            console.log(sabad1.url)
                            const chtml = await sabad1.text();
                            p.innerHTML = chtml;
                        }
                        if (ll == "op3" && n == 1 && p.children.length == 0) {
                            loading(p);
                              const sabad1 = await fetch("/Cart/CartUi")
                              const chtml = await sabad1.text();
                              p.innerHTML = chtml;
                        }
                        if (ll == "op4" && n == 1 && p.children.length == 0) {
                            loading(p);
                            const sabad1 = await fetch("/Category/mcat")
                            const chtml = await sabad1.text();
                            p.style.height = 210 + 'px'
                            p.innerHTML = chtml;
                        }
                        if (ll == "op5" && n == 1 && p.children.length == 0) {
                            loading(p);
                            const sabad1 = await fetch("/Cart/mdcart")
                            const chtml = await sabad1.text();
                       //     p.style.height = 210 + 'px'
                            p.innerHTML = chtml;
                        }






                    });
                  }

                  ////////////////////////////////////////


      function ai() {
        search1.classList.add("ai");
        bo.classList.add("bup");
        bo1.classList.add("bu1p");
        search1.placeholder = 'AI'
        search1.classList.add('ai')


                const categore = document.querySelector('.categories')
                const cate0 = document.querySelector('.cate0')
                const catbb = document.querySelector('.catbb')

                const sele = document.getElementById('sele')

                categore.style.display = 'flex'
                Array.from(cate0.children).forEach((bt) => {

                    Array.from(bt.children).forEach((bt0) => {

                        bt0.addEventListener('click', (t0) => {

                            search1.placeholder = t0.target.textContent
                            sele.value = t0.target.dataset.id

                            //    console.log(sele.value)

                        })

                    })
                })
            }

      function ser() {
                search1.classList.remove('ai')
        search1.classList.remove("ai");
        bo.classList.remove("bup");
        bo1.classList.remove("bu1p");
                search1.placeholder = 'search'

                if (document.querySelector('.categories') != null) {
                    const categor = document.querySelector('.categories')

                    categor.style.display = 'none'
                }
            }


            //////////////////////////////////

      document.addEventListener("click", function (eve) {
        const tel = eve.target;

        if (tel.classList.contains("mah")) {
          const ecl = tel.className;
          const ped = tel.parentElement;
          const rect = tel.getBoundingClientRect();
          const sty = window.getComputedStyle(tel);
          const chi = document.querySelector(".jazire");
          console.log(tel.src);
          chi.dataset.src = `${tel.src}`;
          chi.dataset.id = tel.dataset.id;

          chi.style.marginLeft = eve.clientX + "px";
          chi.style.marginTop =
            window.scrollY -
            col.scrollHeight +
            750 +
            (eve.clientY - window.innerHeight) -
            90 +
            "px";

          chi.classList.remove("re");
          chi.classList.remove("displaynone");
          col.appendChild(chi);
          chi.classList.add("show");

          setTimeout(() => {
            chi.classList.add("re");
            setTimeout(() => {
              chi.classList.add("displaynone");
            }, 350);
          }, 6350);
        }
      });

      function mog() {
        for (const n of amog.children) {
          if (n.src == "") {
            console.log(jazire.dataset.src);
            n.src = jazire.dataset.src;
            break;
          }
        }
        if (mogg.classList.contains("displaynone")) {
          mogg.classList.remove("displaynone");
        }
      }

      function kmog() {
        if (mogpan.classList.contains("displaynone")) {
          mogpan.classList.remove("displaynone");
        }
        for (const [j, n] of Array.from(moga.children).entries()) {
          n.style.backgroundImage = `url(${amog.children[j].src})`;
        }
      }
      function rim(r) {
        const p = document.querySelector(`.${r}`);
        p.style.backgroundImage = "url('')";
      }
      function panca() {
        mogpan.classList.add("displaynone");
      }
      function mogcancel() {
        for (const n of amog.children) {
          n.removeAttribute("src");
        }
        mogg.classList.add("displaynone");
      }
      //////////////////////



      

    async function adlike() {
    const ilike = document.querySelector('.ilike');
    console.log(ilike.value)
            var r = await fetch(`/like/Addlikelist?name=${ilike.value}`)

        slike.insertAdjacentHTML(
          "beforeend",
          `
          <div onclick="slik(${slike.children.length})" class="lselect">
            <img class="sim" src="" alt="">
            <span class="sspan">${ilike.value}</span>
          </div>
        `,
        );
}

            async function llike() {
                const res = await fetch('/like/getlikelist')
                var html = await res.text()
                slike.innerHTML = html
                Array.from(slike.children).forEach((n) => {
                    console.log(n.children[1])
                    n.children[1].addEventListener('click', (p) => {

                        for (const n of slike.children) {
                            n.classList.remove("likebk");
                        }
                        n.classList.add('likebk')
                    })
                })
            }


async function dlike() {
    if (like.classList.contains("displaynone")) {
        llike() 
        like.classList.remove("displaynone");
        like.dataset.id = jazire.dataset.id

    } else {
        const slike = document.querySelector('.slike');
        for (const n of slike.children) {
            console.log(n.classList.contains('likebk'))
            if (n.classList.contains('likebk')) {
                var name = n.children[1].textContent
                var pid = like.dataset.id

                var f = {
                    id: pid,
                    name: name

                }
                console.log(f)
        var r = await fetch(`/like/Addlike`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(f)
        })
            }
        }

        like.classList.add("displaynone");

    }
}
      /////////////////

      async function dview(eve){
                             
      const de = document.querySelector('.detail')
      const id = jazire.dataset.id

 
       console.log("")
       
       de.innerHTML = " <h4> loading... </h4> "
       res = await fetch(`/Products/getp?id=${id}`)
       const html = await res.text();
       de.innerHTML = html


        if (de.classList.contains("displaynone")) {
          de.classList.remove("displaynone");
        } else {
          de.classList.add("displaynone");
        }
       poster3d("poster-3d")
}

///////////////////////

      async function adp(){
 var cartres = await fetch(`/Cart/AddToCart?ProductId=${jazire.dataset.id}`)
     console.log(cartres)
}
/////////////////////////////////





////////////////////////////////
            const sele = document.getElementById('sele')
            const myform = document.getElementById('myform')

        async function sai(e) {
      //      var ress = await fetch(`/Products/SearchAi?Stext=${e}`)
            window.location.href = `/Products/SearchAi?Stext=${e}`
        }

search1.addEventListener("change", (e) => {
    if (search1.classList.contains("ai")) {
        sai(search1.value)

    } else {
                console.log(e.target.value)
                console.log(sele.value)
                myform.submit();
    }

            })
//////////////////////////////
  


async function sendf() {
    const dorder = new FormData()
    const tozih = document.querySelector('.tozih')
    const po_f = document.querySelector('.po_fs')
    const selec = document.querySelector('.seleu')
    const selec1 = document.querySelector('.seleu1')
    const many = document.querySelector('.many')
    dorder.append('tozih', tozih.value)
    dorder.append('imgsrc', po_f.files[0])
    dorder.append('size', selec.dataset.v)
    dorder.append('txchra', selec1.dataset.v)
    dorder.append('count', many.value)
    console.log(dorder)
    const res = await fetch('Cart/AddToCart', {
        method: 'POST',
 body: dorder
    })



}

///////////////////////////////////


Array.from(val).forEach((v) => {
    const selecter = v.children[3];

    Array.from(v.children).forEach((v1) => {
        Array.from(v1.children).forEach((v2) => {
            v2.addEventListener("click", (t) => {
                if (t.target.parentElement.classList.contains("t2")) {
                    console.log(selecter);
                    selecter.style.left = 2 + "%";
                    selecter.dataset.v = '22*33'
                }
                if (t.target.parentElement.classList.contains("t3")) {
                    selecter.style.left = 32 + "%";
                    selecter.dataset.v = '33*44'
                }
                if (t.target.parentElement.classList.contains("t4")) {
                    selecter.style.left = 64 + "%";
                    selecter.dataset.v = '38*48'
                }
            });
        });
    });
});

Array.from(val1).forEach((v) => {
    const selecter = v.children[3];

    Array.from(v.children).forEach((v1) => {
        Array.from(v1.children).forEach((v2) => {
            v2.addEventListener("click", (t) => {
                if (t.target.parentElement.classList.contains("t2")) {
                    console.log(selecter);
                    selecter.style.left = 2 + "%";
                    selecter.dataset.v = 'memory'
                }
                if (t.target.parentElement.classList.contains("t3")) {
                    selecter.style.left = 32 + "%";
                    selecter.dataset.v = 'moat'
                }
                if (t.target.parentElement.classList.contains("t4")) {
                    selecter.style.left = 64 + "%";
                    selecter.dataset.v = 'texra'
                }
            });
        });
    });
});



//////////////////////////////////////////////////////


                               function poster3d(posterim) {
                                    // ======================================================
                                    // SCENE
                                    // ======================================================

                                    const scene = new THREE.Scene();
                                    var container = document.getElementById(posterim);
                                    var posterimg = container.dataset.src;
                                    scene.background =
                                        new THREE.Color(0x171717);


                                    // ======================================================
                                    // CAMERA
                                    // ======================================================

                                    const camera =
                                        new THREE.PerspectiveCamera(

                                            45,

                                            window.innerWidth /
                                            window.innerHeight,

                                            0.1,

                                            1000

                                        );


                                    camera.position.set(
                                        0,
                                        0,
                                        30
                                    );

                                    function fitCameraToContainer() {

                                        const width =
                                            container.clientWidth;

                                        const height =
                                            container.clientHeight;


                                        camera.aspect =
                                            width / height;


                                        camera.updateProjectionMatrix();

                                    }

                                    fitCameraToContainer();
                                    // ======================================================
                                    // RENDERER
                                    // ======================================================


                                    const renderer =
                                        new THREE.WebGLRenderer({

                                            antialias: true

                                        });


                                    renderer.setPixelRatio(

                                        Math.min(
                                            window.devicePixelRatio,
                                            2
                                        )

                                    );


                                    renderer.setSize(

                                        container.clientWidth,
                                        container.clientHeight

                                    );


                                    container.appendChild(
                                        renderer.domElement
                                    );

                                    renderer.outputColorSpace =
                                        THREE.SRGBColorSpace;


                                    renderer.shadowMap.enabled =
                                        true;


                                    renderer.shadowMap.type =
                                        THREE.PCFSoftShadowMap;





                                    // ======================================================
                                    // LIGHTING
                                    // ======================================================

                                    const ambientLight =
                                        new THREE.AmbientLight(

                                            0xffffff,

                                            1.5

                                        );


                                    scene.add(
                                        ambientLight
                                    );
                                    const reflectionLight =
                                        new THREE.DirectionalLight(
                                            0xffffff,
                                            3
                                        );

                                    reflectionLight.position.set(
                                        -8,
                                        2,
                                        8
                                    );

                                    scene.add(reflectionLight);

                                    const keyLight =
                                        new THREE.DirectionalLight(

                                            0xffffff,

                                            4

                                        );


                                    keyLight.position.set(

                                        5,
                                        8,
                                        10

                                    );


                                    keyLight.castShadow =
                                        true;


                                    scene.add(
                                        keyLight
                                    );


                                    const fillLight =
                                        new THREE.DirectionalLight(

                                            0xffffff,

                                            0.8

                                        );


                                    fillLight.position.set(

                                        -6,
                                        3,
                                        8

                                    );


                                    scene.add(
                                        fillLight
                                    );


                                    // ======================================================
                                    // POSTER GROUP
                                    // ======================================================

                                    const poster =
                                        new THREE.Group();


                                    scene.add(
                                        poster
                                    );


                                    // ======================================================
                                    // POSTER SHAPE
                                    // ======================================================

                                    // ابعاد اصلی
                                    const width = 9;
                                    const height = 16;
                                    const thickness = 0.2;


                                    // ------------------------------------------------------
                                    // گوشه‌های گرد
                                    // ------------------------------------------------------

                                    const radius = 0.08;


                                    // ------------------------------------------------------
                                    // ساخت Shape
                                    // ------------------------------------------------------

                                    const shape =
                                        new THREE.Shape();


                                    // شروع از گوشه پایین چپ
                                    shape.moveTo(

                                        -width / 2 + radius,
                                        -height / 2

                                    );


                                    // پایین
                                    shape.lineTo(

                                        width / 2 - radius,
                                        -height / 2

                                    );


                                    // گوشه پایین راست
                                    shape.quadraticCurveTo(

                                        width / 2,
                                        -height / 2,

                                        width / 2,
                                        -height / 2 + radius

                                    );


                                    // راست
                                    shape.lineTo(

                                        width / 2,
                                        height / 2 - radius

                                    );


                                    // گوشه بالا راست
                                    shape.quadraticCurveTo(

                                        width / 2,
                                        height / 2,

                                        width / 2 - radius,
                                        height / 2

                                    );


                                    // بالا
                                    shape.lineTo(

                                        -width / 2 + radius,
                                        height / 2

                                    );


                                    // گوشه بالا چپ
                                    shape.quadraticCurveTo(

                                        -width / 2,
                                        height / 2,

                                        -width / 2,
                                        height / 2 - radius

                                    );


                                    // چپ
                                    shape.lineTo(

                                        -width / 2,
                                        -height / 2 + radius

                                    );


                                    // گوشه پایین چپ
                                    shape.quadraticCurveTo(

                                        -width / 2,
                                        -height / 2,

                                        -width / 2 + radius,
                                        -height / 2

                                    );


                                    // ======================================================
                                    // EXTRUDE GEOMETRY
                                    // ======================================================

                                    const geometry =
                                        new THREE.ExtrudeGeometry(

                                            shape,

                                            {

                                                depth: thickness,

                                                bevelEnabled: true,

                                                bevelSegments: 5,

                                                bevelSize: 0.06,

                                                bevelThickness: 0.06,

                                                curveSegments: 8

                                            }

                                        );


                                    // مرکز هندسه
                                    geometry.center();


                                    // ======================================================
                                    // POSTER MATERIAL
                                    // ======================================================

                                    const posterMaterial =
                                        new THREE.MeshStandardMaterial({

                                            color: 0x8a8a8a,

                                            roughness: 0.12,

                                            metalness: 0.75

                                        });


                                    // ======================================================
                                    // POSTER BODY
                                    // ======================================================

                                    const posterBody =
                                        new THREE.Mesh(

                                            geometry,

                                            posterMaterial

                                        );


                                    posterBody.castShadow =
                                        true;


                                    posterBody.receiveShadow =
                                        true;


                                    poster.add(
                                        posterBody
                                    );


                                    // ======================================================
                                    // IMAGE TEXTURE
                                    // ======================================================

                                    const textureLoader =
                                        new THREE.TextureLoader();


                                    const posterTexture =
                                        textureLoader.load(

                                            `${posterimg}`,

                                            () => {

                                                console.log(
                                                    "Poster image loaded"
                                                );

                                            },

                                            undefined,

                                            (error) => {

                                                console.error(
                                                    "Image loading error:",
                                                    error
                                                );

                                            }

                                        );


                                    posterTexture.colorSpace =
                                        THREE.SRGBColorSpace;


                                    // ======================================================
                                    // IMAGE MATERIAL
                                    // ======================================================

                                    const imageMaterial =
                                        new THREE.MeshStandardMaterial({

                                            map: posterTexture,

                                            roughness: 0.15,

                                            metalness: 0.05,

                                            side: THREE.FrontSide

                                        });


                                    // ======================================================
                                    // IMAGE PLANE
                                    // ======================================================

                                    // کمی کوچک‌تر از خود تابلو
                                    // تا لبه‌ی تابلو مشخص باشد.

                                    const imageWidth =
                                        9;

                                    const imageHeight =
                                        16;


                                    const imageGeometry =
                                        new THREE.PlaneGeometry(

                                            imageWidth,
                                            imageHeight

                                        );


                                    const image =
                                        new THREE.Mesh(

                                            imageGeometry,

                                            imageMaterial

                                        );


                                    // ExtrudeGeometry بعد از center شدن
                                    // ضخامت از -0.25 تا +0.25 است.
                                    //
                                    // سطح جلویی تقریباً:
                                    // Z = +0.25

                                    image.position.z =
                                        thickness / 2 + 0.1;


                                    image.castShadow =
                                        false;


                                    image.receiveShadow =
                                        true;


                                    poster.add(
                                        image
                                    );


                                    // ======================================================
                                    // BACK SIDE
                                    // ======================================================

                                    const backMaterial =
                                        new THREE.MeshStandardMaterial({

                                            color: 0x666666,

                                            roughness: 0.95,

                                            metalness: 0

                                        });


                                    // یک صفحه پشت تابلو
                                    const backGeometry =
                                        new THREE.PlaneGeometry(

                                            9,
                                            16

                                        );


                                    const back =
                                        new THREE.Mesh(

                                            backGeometry,

                                            backMaterial

                                        );


                                    back.rotation.y =
                                        Math.PI;


                                    back.position.z =
                                        -thickness / 2 - 0.002;


                                    poster.add(
                                        back
                                    );


                                    // ======================================================
                                    // FLOOR
                                    // ======================================================




                                    // ======================================================
                                    // ROTATION
                                    // ======================================================

                                    let isDragging = false;


                                    let previousX = 0;
                                    let previousY = 0;


                                    const rotationSpeed =
                                        0.008;


                                    let velocityX = 0;
                                    let velocityY = 0;


                                    const friction =
                                        0.93;


                                    // ======================================================
                                    // POINTER DOWN
                                    // ======================================================

                                    renderer.domElement.addEventListener(

                                        "pointerdown",

                                        (event) => {

                                            isDragging = true;


                                            previousX =
                                                event.clientX;

                                            previousY =
                                                event.clientY;


                                            velocityX = 0;
                                            velocityY = 0;


                                            renderer.domElement.setPointerCapture(

                                                event.pointerId

                                            );

                                        }

                                    );


                                    // ======================================================
                                    // POINTER MOVE
                                    // ======================================================

                                    renderer.domElement.addEventListener(

                                        "pointermove",

                                        (event) => {

                                            if (!isDragging)
                                                return;


                                            const deltaX =
                                                event.clientX -
                                                previousX;


                                            const deltaY =
                                                event.clientY -
                                                previousY;


                                            poster.rotation.y +=

                                                deltaX *
                                                rotationSpeed;


                                            poster.rotation.x +=

                                                deltaY *
                                                rotationSpeed;


                                            velocityX =

                                                deltaX *
                                                rotationSpeed;


                                            velocityY =

                                                deltaY *
                                                rotationSpeed;


                                            previousX =
                                                event.clientX;


                                            previousY =
                                                event.clientY;

                                        }

                                    );


                                    // ======================================================
                                    // POINTER UP
                                    // ======================================================

                                    renderer.domElement.addEventListener(

                                        "pointerup",

                                        (event) => {

                                            isDragging = false;


                                            renderer.domElement.releasePointerCapture(

                                                event.pointerId

                                            );

                                        }

                                    );


                                    renderer.domElement.addEventListener(

                                        "pointercancel",

                                        () => {

                                            isDragging = false;

                                        }

                                    );


                                    // ======================================================
                                    // ROTATION LIMIT
                                    // ======================================================

                                    function limitRotation() {

                                        const xLimit =
                                            Math.PI * 0.45;


                                        poster.rotation.x =
                                            THREE.MathUtils.clamp(

                                                poster.rotation.x,

                                                -xLimit,

                                                xLimit

                                            );

                                    }


                                    // ======================================================
                                    // MOUSE ZOOM
                                    // ======================================================

                                    renderer.domElement.addEventListener(

                                        "wheel",

                                        (event) => {

                                            camera.position.z +=

                                                event.deltaY *
                                                0.01;


                                            camera.position.z =

                                                THREE.MathUtils.clamp(

                                                    camera.position.z,

                                                    12,
                                                    40

                                                );

                                        },

                                        {
                                            passive: true
                                        }

                                    );


                                    // ======================================================
                                    // TOUCH PINCH ZOOM
                                    // ======================================================

                                    let lastTouchDistance =
                                        null;


                                    renderer.domElement.addEventListener(

                                        "touchstart",

                                        (event) => {

                                            if (
                                                event.touches.length === 2
                                            ) {

                                                const dx =

                                                    event.touches[0].clientX -
                                                    event.touches[1].clientX;


                                                const dy =

                                                    event.touches[0].clientY -
                                                    event.touches[1].clientY;


                                                lastTouchDistance =

                                                    Math.sqrt(

                                                        dx * dx +
                                                        dy * dy

                                                    );

                                            }

                                        },

                                        {
                                            passive: false
                                        }

                                    );


                                    // ======================================================
                                    // TOUCH MOVE
                                    // ======================================================

                                    renderer.domElement.addEventListener(

                                        "touchmove",

                                        (event) => {

                                            if (
                                                event.touches.length !== 2
                                            )
                                                return;


                                            event.preventDefault();


                                            const dx =

                                                event.touches[0].clientX -
                                                event.touches[1].clientX;


                                            const dy =

                                                event.touches[0].clientY -
                                                event.touches[1].clientY;


                                            const distance =

                                                Math.sqrt(

                                                    dx * dx +
                                                    dy * dy

                                                );


                                            if (
                                                lastTouchDistance !== null
                                            ) {

                                                const difference =

                                                    distance -
                                                    lastTouchDistance;


                                                camera.position.z -=

                                                    difference *
                                                    0.02;


                                                camera.position.z =

                                                    THREE.MathUtils.clamp(

                                                        camera.position.z,

                                                        12,
                                                        40

                                                    );

                                            }


                                            lastTouchDistance =
                                                distance;

                                        },

                                        {
                                            passive: false
                                        }

                                    );


                                    // ======================================================
                                    // TOUCH END
                                    // ======================================================

                                    renderer.domElement.addEventListener(

                                        "touchend",

                                        () => {

                                            lastTouchDistance =
                                                null;

                                        }

                                    );


                                    // ======================================================
                                    // ANIMATION
                                    // ======================================================

                                    function animate() {

                                        requestAnimationFrame(
                                            animate
                                        );


                                        if (!isDragging) {

                                            poster.rotation.y +=
                                                velocityX;

                                            poster.rotation.x +=
                                                velocityY;


                                            velocityX *=
                                                friction;

                                            velocityY *=
                                                friction;

                                        }


                                        limitRotation();


                                        renderer.render(

                                            scene,

                                            camera

                                        );

                                    }


                                    animate();


                                    // ======================================================
                                    // RESIZE
                                    // ======================================================

                                    window.addEventListener(

                                        "resize",

                                        () => {

                                            camera.aspect =

                                                window.innerWidth /
                                                window.innerHeight;


                                            camera.updateProjectionMatrix();


                                            renderer.setSize(

                                                window.innerWidth,
                                                window.innerHeight

                                            );

                                        }

                                    );
                                }
