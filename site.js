// DROPDOWN

document.querySelectorAll('.dropdown-content a').forEach(item => {
  item.addEventListener('click', function(event) {
    const dropbtn = document.querySelector('.dropbtn');
    dropbtn.textContent = this.textContent;

    const dropdownContent = document.querySelector('.dropdown-content');
    dropdownContent.style.display = 'none';
  });
});
  
document.querySelector('.dropbtn').addEventListener('click', function(event) {
  const dropdownContent = document.querySelector('.dropdown-content');
  dropdownContent.style.display = dropdownContent.style.display === 'block' ? 'none' : 'block';
});

// ROLAGEM SUAVE

$('a[href="#top"]').on('click', function (event) {
  event.preventDefault();
  $('html, body').animate({ scrollTop: 0 }, 1500);
});

$('a[href^="#"]').on('click', function (event) {
  event.preventDefault();
  const target = $(this.getAttribute('href'));
  if (target.length) {
    $('html, body').animate({
      scrollTop: target.offset().top
    }, 1500);
}});

// MODO ESCURO / CLARO

function toggleWord(event) {
  event.preventDefault();

  const textElement = document.getElementById('toggle-Text');
  const imageElement = document.querySelector('.rotating-image');

  const isDark = document.documentElement.getAttribute('data-theme') === 'dark';

  if (isDark) {
    textElement.textContent = 'Dark';
    textElement.classList.remove('light-text');
    textElement.classList.add('dark-text');
    imageElement.classList.remove('rotate');
    document.documentElement.setAttribute('data-theme', 'light');
    localStorage.setItem('theme', 'light');
  } else {
    textElement.textContent = 'Light';
    textElement.classList.remove('dark-text');
    textElement.classList.add('light-text');
    imageElement.classList.add('rotate');
    document.documentElement.setAttribute('data-theme', 'dark');
    localStorage.setItem('theme', 'dark');
  }

  videoElement.load();
  videoElement.play();
}

function loadTheme() {
  const savedTheme = localStorage.getItem('theme') || 'light';

  document.documentElement.setAttribute('data-theme', savedTheme);

  const textElement = document.getElementById('toggle-Text');
  const imageElement = document.querySelector('.rotating-image');
}

  if (savedTheme === 'dark') {
    textElement.textContent = 'Light';
    textElement.classList.remove('light-text');
    textElement.classList.add('dark-text');
    imageElement.classList.add('rotate');
  } else {
    textElement.textContent = 'Dark';
    textElement.classList.remove('dark-text');
    textElement.classList.add('light-text');
    imageElement.classList.remove('rotate');
  }

window.addEventListener('DOMContentLoaded', loadTheme);