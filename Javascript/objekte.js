
// Object litaral pattern
let car1 = {
    year: 2000,
    make: 'Ford',
    model: "Fusion",
    getInfo: function () {
        return 'Vehicle: ' + this.year + ' ' + this.make + ' ' + this.model;
    }
};

let car2 = {
    year: 2010,
    make: 'BMW',
    model: 'Z4',
    getInfo: function () {
        return 'Vehicle: ' + this.year + ' ' + this.make + ' ' + this.model;
    }
}


console.log(car1.getInfo());
console.log(car1.year);
console.log(car1.make);
console.log(car1.model);

console.log(car2.getInfo());
console.log(car2.year);
console.log(car2.make);
console.log(car2.model);


// Objekte über das Factory Pattern
function getVehicle(theYear, theMake, theModel){
    let vehicle = new Object();
    vehicle.year = theYear;
    vehicle.make = theMake;
    vehicle.model = theModel;
    vehicle.getInfo = function () {
        return 'Vehicle: ' + this.year + ' ' + this.make + ' ' + this.model;
    };
    return vehicle;
}

let car3 = getVehicle(2015,'VW','Golf');
console.log(car3.getInfo());

car3.year = 2016;
console.log(car3.getInfo()); // public Property

//Erstellen einer Klasse
function Vehicle(theYear, theMake, theModel){
    let year = theYear;
    let make = theMake;
    let model = theModel;
    // this.getInfo = function () {
    //     return 'Vehicle: ' + year + ' ' + make + ' ' + model;
    // };
    this.getYear = function () {return year;};
    this.getMake = function () {return make;};
    this.getModel = function () {return model;};
}
Vehicle.prototype.getInfo = function () {
    return 'Vehicle: ' + this.getYear() + ' ' + this.getMake() + ' ' + this.getModel();
}

let car4 = new Vehicle(2020,"VW","Golf");
console.log(car4);
console.log(car4.year);

car4.year = 1000;
console.log(car4.year);


console.log(car4);
console.log(car4.getInfo());

