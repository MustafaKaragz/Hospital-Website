function filterDoctors() {
    var input, filter, cards, cardContainer, h3, title, i;
    input = document.getElementById('search-box');
    filter = input.value.toUpperCase();
    cardContainer = document.querySelector('.doctor-grid');
    cards = cardContainer.getElementsByClassName('doctor-card');

    for (i = 0; i < cards.length; i++) {
        h3 = cards[i].getElementsByTagName('h3')[0];
        if (h3) {
            title = h3.textContent || h3.innerText;
            if (title.toUpperCase().indexOf(filter) > -1) {
                cards[i].style.display = "";
            } else {
                cards[i].style.display = "none";
            }
        }
    }
}

function filterByDepartment() {
    var select, filter, cards, cardContainer, p, department, i;
    select = document.getElementById('department-filter');
    filter = select.value;
    cardContainer = document.querySelector('.doctor-grid');
    cards = cardContainer.getElementsByClassName('doctor-card');

    for (i = 0; i < cards.length; i++) {
        p = cards[i].getElementsByTagName('p')[0];
        if (p) {
            department = p.textContent || p.innerText;
            if (filter === 'all' || department === filter) {
                cards[i].style.display = "";
            } else {
                cards[i].style.display = "none";
            }
        }
    }
}