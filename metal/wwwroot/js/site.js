// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function loadData() {

    const response = await fetch('/Home/Db');

    console.log(response.status);

    const posters = await response.json();

    console.log(posters);

    for (let i = 0; i < posters.length; i++) {
        console.log(posters[i].src);
    }
}

loadData();
