let Vehicle = (function(){
    function Vehicle (theYear, make, model){
        let year = theYear;
        this.make = make;
        this.model = model;
        this.getYear = function(){return year;}
    }
    Vehicle.prototype.getInfo = function () {
        return "Info " + this.getYear() + " " + this.make + " " + this.model;
    }
    return Vehicle;
})();

let myVehicle = new Vehicle(1200,"a","B");
console.log(myVehicle.getInfo());

let Car = (function(parent){
    Car.prototype = new Vehicle();
    Car.prototype.constructor = Car;
    function Car(year, make, model){
        parent.call(this, year, make, model);
        this.wheels = 4;
    }
    Car.prototype.getInfo = function () {
        return "Vehicle Type: Car \nWheels: " + this.wheels + "\n" + parent.prototype.getInfo.call(this);
    }
    return Car;
})(Vehicle);

let myCar = new Car(2021, "Dacia", "Sondero");
console.log(myCar.getInfo());

