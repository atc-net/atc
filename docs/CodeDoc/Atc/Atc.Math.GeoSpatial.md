<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Math.GeoSpatial

<br />

## DistanceMeasurementType
DistanceMeasurementType

>```csharp
>public enum DistanceMeasurementType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Meters | Meters | The meters. | 
| 1 | Feet | Feet | The feet. | 
| 2 | Kilometers | Kilometers | The kilometers. | 
| 3 | StatuteMiles | Statute Miles | The statute miles. | 
| 4 | NauticalMiles | Nautical Miles | The nautical miles. | 



<br />

## GeoSpatialHelper
Provides utility methods for geospatial calculations including distance measurements between geographic coordinates.

>```csharp
>public static class GeoSpatialHelper
>```

### Static Methods

#### Distance
>```csharp
>double Distance(CartesianCoordinate coordinate1, CartesianCoordinate coordinate2, DistanceMeasurementType measurement)
>```
><b>Summary:</b> Calculates the great-circle distance between two geographic coordinates.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate1`&nbsp;&nbsp;-&nbsp;&nbsp;The first coordinate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate2`&nbsp;&nbsp;-&nbsp;&nbsp;The second coordinate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`measurement`&nbsp;&nbsp;-&nbsp;&nbsp;The unit of measurement for the result.<br />
>
><b>Returns:</b> The distance between the two coordinates in the specified measurement unit.
#### Distance
>```csharp
>double Distance(double longitude1, double latitude1, double longitude2, double latitude2, DistanceMeasurementType measurement = Kilometers)
>```
><b>Summary:</b> Calculates the great-circle distance between two geographic coordinates.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate1`&nbsp;&nbsp;-&nbsp;&nbsp;The first coordinate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate2`&nbsp;&nbsp;-&nbsp;&nbsp;The second coordinate.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`measurement`&nbsp;&nbsp;-&nbsp;&nbsp;The unit of measurement for the result.<br />
>
><b>Returns:</b> The distance between the two coordinates in the specified measurement unit.

<br />

## ReferenceEllipsoidType
ReferenceEllipsoidType

>```csharp
>public enum ReferenceEllipsoidType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Airy | Airy | The airy. | 
| 1 | AustralianNational | Australian National | The australian national. | 
| 2 | Bessel1841 | Bessel1841 | The bessel 1841. | 
| 3 | Bessel1841Nambia | Bessel1841 Nambia | The bessel 1841 nambia. | 
| 4 | Clarke1866 | Clarke1866 | The clarke 1866. | 
| 5 | Clarke1880 | Clarke1880 | The clarke 1880. | 
| 6 | Everest | Everest | The everest. | 
| 7 | Fischer1960Mercury | Fischer1960 Mercury | The fischer1960 mercury. | 
| 8 | Fischer1968 | Fischer1968 | The fischer1968. | 
| 9 | Grs1967 | Grs1967 | The GRS 1967 (Geodetic Reference System). | 
| 10 | Grs1980 | Grs1980 | The GRS 1980 (Geodetic Reference System). | 
| 11 | Helmert1906 | Helmert1906 | The helmert 1906. | 
| 12 | Hough | Hough | The hough. | 
| 13 | International | International | The international. | 
| 14 | Krassovsky | Krassovsky | The krassovsky. | 
| 15 | ModifiedAiry | Modified Airy | The modified airy. | 
| 16 | ModifiedEverest | Modified Everest | The modified everest. | 
| 17 | ModifiedFischer1960 | Modified Fischer1960 | The modified fischer 1960. | 
| 18 | SouthAmerican1969 | South American1969 | The south american 1969. | 
| 19 | Ed50 | Ed50 | The ED50 (European Datum 1950) - International Ellipsoid. | 
| 20 | Wgs60 | Wgs60 | The WGS 60 (World Geodetic System). | 
| 21 | Wgs66 | Wgs66 | The WGS 66 (World Geodetic System). | 
| 22 | Wgs72 | Wgs72 | The WGS 72 (World Geodetic System). | 
| 23 | Wgs84 | Wgs84 | The WGS 84 (World Geodetic System). | 
| 24 | Euref89 | Euref89 | The EUREF89 (European Terrestrial Reference System) - Max deviation from WGS 84 is 40 cm/km see http://ocq.dk/euref89 (in danish). | 
| 25 | Etrs89 | Etrs89 | The ETRS89 (European Terrestrial Reference System) - Same as EUREF89. | 



<br />

## UniversalTransverseMercatorConverter
UniversalTransverseMercatorConverter

>```csharp
>public class UniversalTransverseMercatorConverter
>```

### Methods

#### ToUtm
>```csharp
>UniversalTransverseMercatorResult ToUtm(CartesianCoordinate coordinate)
>```
><b>Summary:</b> To UTM.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate`&nbsp;&nbsp;-&nbsp;&nbsp;The coordinate.<br />
#### ToUtm
>```csharp
>UniversalTransverseMercatorResult ToUtm(double latitude, double longitude)
>```
><b>Summary:</b> To UTM.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate`&nbsp;&nbsp;-&nbsp;&nbsp;The coordinate.<br />
#### ToWgs84
>```csharp
>CartesianCoordinate ToWgs84(int utmZoneNumber, string utmZoneLetter, double utmEasting, double utmNorthing, int maxDecimalPrecision = 8)
>```
><b>Summary:</b> To WGS84.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`utmZoneNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The utm zone number.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`utmZoneLetter`&nbsp;&nbsp;-&nbsp;&nbsp;The utm zone letter.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`utmEasting`&nbsp;&nbsp;-&nbsp;&nbsp;The utm easting.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`utmNorthing`&nbsp;&nbsp;-&nbsp;&nbsp;The utm northing.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxDecimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum decimal precision.<br />

<br />

## UniversalTransverseMercatorResult
UniversalTransverseMercatorResult

>```csharp
>public class UniversalTransverseMercatorResult
>```

### Properties

#### FormattedUtm
>```csharp
>FormattedUtm
>```
><b>Summary:</b> Gets the formatted UTM.
#### UtmEasting
>```csharp
>UtmEasting
>```
><b>Summary:</b> Gets the utm easting.
#### UtmNorthing
>```csharp
>UtmNorthing
>```
><b>Summary:</b> Gets the utm northing.
#### Zone
>```csharp
>Zone
>```
><b>Summary:</b> Gets the zone.
#### ZoneLetter
>```csharp
>ZoneLetter
>```
><b>Summary:</b> Gets the zone letter.
#### ZoneNumber
>```csharp
>ZoneNumber
>```
><b>Summary:</b> Gets the zone number.
### Methods

#### ToString
>```csharp
>string ToString()
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
