# openapi.model.CarDto

## Load the model package
```dart
import 'package:openapi/api.dart';
```

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **String** |  | [optional] 
**userId** | **String** |  | [optional] 
**make** | **String** |  | [optional] 
**model** | **String** |  | [optional] 
**year** | **String** |  | [optional] 
**color** | **String** |  | [optional] 
**engineSerialNumber** | **String** |  | [optional] 
**inspections** | [**List<InspectionBriefDto>**](InspectionBriefDto.md) |  | [optional] [default to const []]
**documents** | [**List<DocumentBriefDto>**](DocumentBriefDto.md) |  | [optional] [default to const []]
**owner** | [**Object**](.md) |  | [optional] 
**status** | **String** |  | [optional] 
**isReleased** | **bool** |  | [optional] 
**release** | [**ReleaseDto**](ReleaseDto.md) |  | [optional] 
**ownerDetails** | [**UserDetailsResponse**](UserDetailsResponse.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


