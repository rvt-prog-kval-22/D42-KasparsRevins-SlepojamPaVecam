const navSlide = ()=>{
    const burger = document.querySelector('.burger');
    const nav = document.querySelector('.feature-box');
    const navFeature = document.querySelectorAll('.feature-box li');
    
    //Toggle Navigation Bar
    burger.addEventListener('click',()=>{
        nav.classList.toggle('nav-active');
     
        //Animate Links
        navFeature.forEach((link, index)=>{
            if (link.style.animation){
                link.style.animation = '';
            } else {
                link.style.animation = 'navLinkFade 0.5s ease forwards ${index / 7 + 0.3}s'
            }
        });
        //Burger Animation
        burger.classList.toggle('toggle');
    });
    
}

navSlide();