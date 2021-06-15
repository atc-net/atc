<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Math.GeoSpatial

<br />


## DistanceMeasurementType
DistanceMeasurementType


```csharp
public enum DistanceMeasurementType
```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | Meters | Meters | The meters. | 
| 1 | Feet | Feet | The feet. | 
| 2 | Kilometers | Kilometers | The kilometers. | 
| 3 | StatuteMiles | Statute Miles | The statute miles. | 
| 4 | NauticalMiles | Nautical Miles | The nautical miles. | 



<br />


## GeoSpatialHelper
GeoSpatialHelper


```csharp
public static class GeoSpatialHelper
```

### Static Methods


#### Distance

```csharp
double Distance(CartesianCoordinate coordinate1, CartesianCoordinate coordinate2, DistanceMeasurementType measurement)
```
<p><b>Summary:</b> Calculate distance.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate1`&nbsp;&nbsp;-&nbsp;&nbsp;The coordinate1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate2`&nbsp;&nbsp;-&nbsp;&nbsp;The coordinate2.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`measurement`&nbsp;&nbsp;-&nbsp;&nbsp;The measurement.<br />
#### Distance

```csharp
double Distance(double longitude1, double latitude1, double longitude2, double latitude2, DistanceMeasurementType measurement = Kilometers)
```
<p><b>Summary:</b> Calculate distance.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate1`&nbsp;&nbsp;-&nbsp;&nbsp;The coordinate1.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate2`&nbsp;&nbsp;-&nbsp;&nbsp;The coordinate2.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`measurement`&nbsp;&nbsp;-&nbsp;&nbsp;The measurement.<br />

<br />


## ReferenceEllipsoidType
ReferenceEllipsoidType


```csharp
public enum ReferenceEllipsoidType
```


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


```csharp
public class UniversalTransverseMercatorConverter
```

### Methods


#### ToUtm

```csharp
UniversalTransverseMercatorResult ToUtm(CartesianCoordinate coordinate)
```
<p><b>Summary:</b> To UTM.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate`&nbsp;&nbsp;-&nbsp;&nbsp;The coordinate.<br />
#### ToUtm

```csharp
UniversalTransverseMercatorResult ToUtm(double latitude, double longitude)
```
<p><b>Summary:</b> To UTM.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`coordinate`&nbsp;&nbsp;-&nbsp;&nbsp;The coordinate.<br />
#### ToWgs84

```csharp
CartesianCoordinate ToWgs84(int utmZoneNumber, string utmZoneLetter, double utmEasting, double utmNorthing, int maxDecimalPrecision = 8)
```
<p><b>Summary:</b> To WGS84.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`utmZoneNumber`&nbsp;&nbsp;-&nbsp;&nbsp;The utm zone number.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`utmZoneLetter`&nbsp;&nbsp;-&nbsp;&nbsp;The utm zone letter.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`utmEasting`&nbsp;&nbsp;-&nbsp;&nbsp;The utm easting.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`utmNorthing`&nbsp;&nbsp;-&nbsp;&nbsp;The utm northing.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`maxDecimalPrecision`&nbsp;&nbsp;-&nbsp;&nbsp;The maximum decimal precision.<br />

<br />


## UniversalTransverseMercatorResult
UniversalTransverseMercatorResult


```csharp
public class UniversalTransverseMercatorResult
```

### Properties


#### FormattedUtm

```csharp
FormattedUtm
```
<p><b>Summary:</b> Gets the formatted UTM.</p>

#### UtmEasting

```csharp
UtmEasting
```
<p><b>Summary:</b> Gets the utm easting.</p>

#### UtmNorthing

```csharp
UtmNorthing
```
<p><b>Summary:</b> Gets the utm northing.</p>

#### Zone

```csharp
Zone
```
<p><b>Summary:</b> Gets the zone.</p>

#### ZoneLetter

```csharp
ZoneLetter
```
<p><b>Summary:</b> Gets the zone letter.</p>

#### ZoneNumber

```csharp
ZoneNumber
```
<p><b>Summary:</b> Gets the zone number.</p>

### Methods


#### ToString

```csharp
string ToString()
```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
