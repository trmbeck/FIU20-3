const Kunde =  (function(){
    function Kunde(nachname, vorname, adresse, geburtsdatum){
        let _id;
        let _nachname = nachname;
        let _vorname = vorname;
        let _adresse = adresse;
        let _geburtsdatum = geburtsdatum;
        this.getId = function(){return _id;}
        this.getVorname = function(){return _vorname;}
        this.getNachname = function(){return _nachname;}
        this.getAdresse = function(){return _adresse;}
        this.getGeburtsdatum = function(){return _geburtsdatum;}
        this.setVorname = function(vorname){_vorname = vorname;}
        this.setNachname = function(nachname){_nachname = nachname;}
        this.setAdresse = function(adresse){_adresse = adresse;}
        this.setGeburtsdatum = function(geburtsdatum){_geburtsdatum = geburtsdatum;}
        _id = IdPointer;
        IdPointer++;
        return _id;
    }
    Kunde.prototype.getInfo = function(){
        return this.getNachname() + ', ' + this.getVorname() + '\r\n' + this.getAdresse() + '\r\n' + this.getGeburtsdatum();
    }
    Kunde.prototype.getJSON = function(){
        return '{"id":'+this.getId()+', "nachname":"'+this.getNachname()+'", "vorname":"'+this.getVorname()+'", "adresse":"'+this.getAdresse()+'", "geburtsdatum":"'+this.getGeburtsdatum()+'"}';
    }
    Kunde.getIdPointer = function () {return IdPointer;}
    let IdPointer = 1;    
    return Kunde;
})()
module.exports = Kunde;