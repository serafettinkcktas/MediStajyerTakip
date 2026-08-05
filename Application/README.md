### APPLICATION KATMANI 
bu katman bizim tum kontrollerimizin oldugu katman. buraya gelen istek uygun formattaysa bir sonraki 
adima geceebilir degilse geri gonderilmelidir. 
burada su sekilde bir akis olmali api den gelen istek validasyon kurallarina uygun degilse geri gonderiir
eger uygunsa gerekli metotlar cagirilarak repository ile iletisim kurulur. repositoryden gelen
cevaplara gore burada yeni bir metot tetiklenir veya kullaniciya bir sonuc gonderilir. 

### UseCases 
use caseler bize gonderilen hangi istegin nerede islenecegini gosteren siniflardir. ornegin mentor ekleme
istegi geldiginde bu istek `addmentorusecase` icerisinde islenmelidir. 

### Dtos 
dtolar bizim veri tasima nesnelerimizdir bu nesneler donus verisi veya istek erisi icerebilirler

### Helpers 
helper siniflar repository katmanina istek gonderirken orada kullanima uygun tam olarak hazirlanmis
nesneler uretmemize yardim eden siniflardir. ornegin bir kullanici eklenecegi zaman kullanicinin 
neredeyse tum bilgileri bu helper sinif icerisinde hazirlanmakta ve repository katmaninda ise 
veritabani kaydi yapilmaktadir.

### Validation 
validasyon kisminda fluent validation kullaniyoruz fluent validation bir sinifin icerdigi degiskenlere
bakarak bunlara ait istedimiz ozellikleri secebilmemizi saglayan nesnelerdir. her bir istek turu 
icin ayri bir validasyon sinifi olusturulabilir bu da bize ui tarafina donecegimiz cevap 
kisminda buyuk kolaylik saglar 

### Command
command kisminda islenecek isteklerin temel ozellikleri yer almalidir. ornegin bir mentor eklenirken 
kullanicinin vermesi gereken degerler name,surname,email degerleridir. api kisminda controller icerisinde
dogrudan bu command nesnesi kullanicidan istenebilir. suanlik cqrs pattern olarak kurmadim ama
eger sorun olmaz dersen onu da kurabiliriz cqrs patterni biraz arastirip bilgi sahibi olduktan sonra
fikrini bekliyorum. 