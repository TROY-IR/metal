
import * as THREE from "https://unpkg.com/three@0.162.0/build/three.module.js";

const jbt1 = document.querySelector('.jbt1')

jbt1.addEventListener('click',  async (eve) => {

    const de = document.querySelector('.detail')
    const jazire = document.querySelector(".jazire");
    const id = jazire.dataset.id


    console.log("")

    de.innerHTML = " <h4> loading... </h4> "
    var res = await fetch(`/Products/getp?id=${id}`)
    const html = await res.text();
    de.innerHTML = html


    if (de.classList.contains("displaynone")) {
        de.classList.remove("displaynone");
    } else {
        de.classList.add("displaynone");
    }
    poster3d("poster-3d")
}
)

export  function poster3d(posterim) {
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

