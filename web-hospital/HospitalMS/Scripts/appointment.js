document.addEventListener('DOMContentLoaded', function () {
    const monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];
    const today = new Date();
    let currentMonth = today.getMonth();
    let currentYear = today.getFullYear();

    const prevMonth = document.getElementById('prevMonth');
    const nextMonth = document.getElementById('nextMonth');

    function highlightSelectedDate(cell) {

        document.querySelectorAll('#calendar-body td').forEach(td => {
            td.classList.remove('bg-selected');
        });

        cell.classList.add('bg-selected');
    }

    function createCalendar(month, year) {
        let firstDay = new Date(year, month).getDay();
        firstDay = (firstDay === 0 ? 6 : firstDay - 1);
        let daysInMonth = 32 - new Date(year, month, 32).getDate();
        let tbl = document.getElementById("calendar-body");

        tbl.innerHTML = "";
        document.getElementById("monthYear").innerHTML = monthNames[month] + " " + year;

        let date = 1;
        for (let i = 0; i < 6; i++) {
            let row = document.createElement("tr");

            for (let j = 0; j < 7; j++) {
                if (i === 0 && j < firstDay) {
                    row.insertCell();
                } else if (date > daysInMonth) {
                    break;
                } else {
                    let cell = row.insertCell();
                    cell.textContent = date;

                    if (date === today.getDate() && year === today.getFullYear() && month === today.getMonth()) {
                        cell.classList.add("bg-info");
                    } else {
                        cell.addEventListener('click', (function (d, cellElement) {
                            return function () {
                                highlightSelectedDate(cellElement);
                            }
                        })(date, cell));
                    }
                    date++;
                }
            }

            tbl.appendChild(row);
        }
    }

    prevMonth.onclick = function () {
        currentMonth = currentMonth - 1;
        if (currentMonth < 0) {
            currentMonth = 11;
            currentYear = currentYear - 1;
        }
        createCalendar(currentMonth, currentYear);
    };

    nextMonth.onclick = function () {
        currentMonth = currentMonth + 1;
        if (currentMonth > 11) {
            currentMonth = 0;
            currentYear = currentYear + 1;
        }
        createCalendar(currentMonth, currentYear);
    };

    createCalendar(currentMonth, currentYear);


    const departmentDoctors = {
        "neurology": [{ "value": "hakan", "text": "Hakan Gundogan" }, { "value": "arzu", "text": "Arzu Keskin" }],
        "cardiology": [{ "value": "huseyin", "text": "Huseyin Dal" }, { "value": "ibrahim", "text": "Ibrahim Usta" }],
        "pediatrics": [{ "value": "naci", "text": "Naci Celik" }],
        "dermatology": [{ "value": "melih", "text": "Melih Kasimoglu" }, { "value": "okan", "text": "Okan Bas" }],
        "orthopedics": [{ "value": "guncel", "text": "Guncel Ozturk" }],
        "hematology": [{ "value": "neslihan", "text": "Neslihan Senocak" }, { "value": "david", "text": "David Ruacan" }],
        "urology": [{ "value": "alev", "text": "Alev Kilic" }, { "value": "dogus", "text": "Dogus Kiran" }],

    };

    const departmentSelect = document.getElementById('department');
    const doctorSelect = document.getElementById('doctor');

    departmentSelect.addEventListener('change', function () {
        const selectedDepartment = this.value;
        updateDoctors(selectedDepartment);
    });

    function updateDoctors(department) {
        doctorSelect.innerHTML = '';
        if (departmentDoctors[department]) {
            departmentDoctors[department].forEach(function (doctor) {
                const option = document.createElement('option');
                option.value = doctor.value;
                option.textContent = doctor.text;
                doctorSelect.appendChild(option);
            });
        } else {

            const defaultOption = document.createElement('option');
            defaultOption.textContent = 'Select Doctor';
            defaultOption.value = '';
            doctorSelect.appendChild(defaultOption);
        }
    }

    updateDoctors(departmentSelect.value);


    const appointmentForm = document.getElementById('appointmentForm');
    const selectedDateElement = document.getElementById('selectedDate');

    appointmentForm.addEventListener('submit', function (event) {
        event.preventDefault();

        console.log('Form submitted!');

        const department = document.getElementById('department').value;
        const doctor = document.getElementById('doctor').value;
        const firstName = document.getElementById('firstName').value;
        const lastName = document.getElementById('lastName').value;
        const email = document.getElementById('email').value;

        if (!department || !doctor || !firstName || !lastName || !email) {
            alert('Please enter all required information.');
            return;
        }


        const selectedDate = document.querySelector('.bg-selected');
        if (!selectedDate) {
            alert('Please select a date from the calendar.');
            return;
        }


        const year = currentYear;
        const month = currentMonth;
        const day = selectedDate.textContent;


        


        appointmentForm.reset();


        alert('Your appointment has been successfully booked!');

        console.log('After form processing');
    });

});