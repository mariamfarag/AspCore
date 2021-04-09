//1 var winH = screen.height;
//console.log(winH);
//2var navH = document.querySelector(".navbar").style.height.split("px")[0];
//console.log(navH)
//console.log((winH - navH));
//result = winH - navH
//console.log(result);


//3document.querySelector(".slider").style.height = (winH - navH);

//document.querySelector(".slider").style.height = (winH - navH) + "px" + " " + "!important";
//console.log(x);

//start login
function openLogin() {
    document.getElementById("overlay").style.display = "block";
    document.getElementById("form-popup").style.display = "block";
}

function closeLogin() {
    document.getElementById("overlay").style.display = "none";
    document.getElementById("form-popup").style.display = "none";
}
//end login

//start shuffling img
const btn = document.querySelectorAll(".list-unstyled li");
const product = document.querySelectorAll(".itembox");

btn.forEach(item => {
        item.addEventListener("click", function() {
            for (let i = 0; i < btn.length; i++) {
                btn[i].classList.remove("active");
            }
            item.classList.add("active");

            product.forEach(show => {
                show.style.opacity = 0.2;
                let products = item.textContent.toLowerCase();
                //console.log(products);
                if (show.getAttribute("data-att") === products || products === "all") {
                    show.style.opacity = 1;


                }
            })
        })
    })
    //end shuffling img