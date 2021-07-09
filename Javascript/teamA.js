var teamA = teamA || {}

teamA.subnamespace = teamA.subnamespace || {} //Untergeordneter Namespace

teamA.vehicleCount = 5;

teamA.vehicle = new Array();

teamA.Car = function (){
    console.log("Car function\nVehicleCount" + teamA.vehicleCount);
}

teamA.Truck = function (){
    console.log("Truck function");
}

teamA.repair = {
    description: 'change spark plugs',
    cost: 100
}

let car2 = new teamB.Vehicle(2000);
console.log(car2.getInfo());
// IIFE - Imidiatly Invoked Function Expression
// (function (testParam){
//     console.log("test Function " + testParam);
// })("Argument")