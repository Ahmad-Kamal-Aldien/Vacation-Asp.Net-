//$(function () {
//    getVacationType();
//});

$(document).ready(() => {
    getVacationType();
});



 getEmp=()=> {

     let empValue = $('#txtemp').val();

     $.ajax({
        //url: `/Empolyee/GetNames/${$('#txtemp').val()}`,
        url: `/Empolyee/GetNames`,
         method: 'GET',
         data: { name: empValue },
        cache: false,
        success: (data) => {
            let emp = '';
             emp = `<option selected value="">Item Found(${data.length})</option>`;
            for (x in data) {
                          emp += `<option value="${data[x].id}">${data[x].name}</option>`;

                   }
                     $("#selectemp").html(emp);

        }
    });
}

function getVacationType(){

    $.ajax({
        url: '/VacationType/GetNames',
        cache: false,
        method: 'GET',
        success: (data) => {
            let vacationType = '';
            vacationType += `<option value="" selected>Select Vacation Types (${data.length}) </option>`;
            for (i in data) {
                vacationType += `<option 
                value="${data[i].id}"
                style="background-color:${data[i].color}">${data[i].name}-----Day (${data[i].numberOfDays})</option>`;

            }
            $("#vacationType").html(vacationType);
        }
    });
}

//getEmp = () => {
//function getEmp() {
//    alert("Hello");

//    $.ajax({

//        // URL:"/Empolyee/GetNames/$('#txtemp').val()",

//        // URL:'/Empolyee/GetNames/' +$('#txtemp').val()",
//        URL: `/Empolyee/GetNames/${$('#txtemp').val()}`,

//        Cache: false,
//        Method: "GET",
//        success=(data) => {

//            let emp = `<option selected value="">Item Found(${data.length})</option>`;
//            for (x in data) {
//                emp += `<option value="${data[x].id}">${data[x].name}</option>`;

//            }
//            $("#selectemp").html(emp);
//        }
//    });
//}