# openapi.api.AuthenticationDevApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**getApiAuthenticationDevConfirmEmail**](AuthenticationDevApi.md#getapiauthenticationdevconfirmemail) | **GET** /api/AuthenticationDev/confirmEmail | 
[**getApiAuthenticationDevManageInfo**](AuthenticationDevApi.md#getapiauthenticationdevmanageinfo) | **GET** /api/AuthenticationDev/manage/info | 
[**postApiAuthenticationDevForgotPassword**](AuthenticationDevApi.md#postapiauthenticationdevforgotpassword) | **POST** /api/AuthenticationDev/forgotPassword | 
[**postApiAuthenticationDevLogin**](AuthenticationDevApi.md#postapiauthenticationdevlogin) | **POST** /api/AuthenticationDev/login | 
[**postApiAuthenticationDevManage2fa**](AuthenticationDevApi.md#postapiauthenticationdevmanage2fa) | **POST** /api/AuthenticationDev/manage/2fa | 
[**postApiAuthenticationDevManageInfo**](AuthenticationDevApi.md#postapiauthenticationdevmanageinfo) | **POST** /api/AuthenticationDev/manage/info | 
[**postApiAuthenticationDevRefresh**](AuthenticationDevApi.md#postapiauthenticationdevrefresh) | **POST** /api/AuthenticationDev/refresh | 
[**postApiAuthenticationDevRegister**](AuthenticationDevApi.md#postapiauthenticationdevregister) | **POST** /api/AuthenticationDev/register | 
[**postApiAuthenticationDevResendConfirmationEmail**](AuthenticationDevApi.md#postapiauthenticationdevresendconfirmationemail) | **POST** /api/AuthenticationDev/resendConfirmationEmail | 
[**postApiAuthenticationDevResetPassword**](AuthenticationDevApi.md#postapiauthenticationdevresetpassword) | **POST** /api/AuthenticationDev/resetPassword | 


# **getApiAuthenticationDevConfirmEmail**
> getApiAuthenticationDevConfirmEmail(userId, code, changedEmail, acceptLanguage)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final userId = userId_example; // String | 
final code = code_example; // String | 
final changedEmail = changedEmail_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    api_instance.getApiAuthenticationDevConfirmEmail(userId, code, changedEmail, acceptLanguage);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->getApiAuthenticationDevConfirmEmail: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **String**|  | [optional] 
 **code** | **String**|  | [optional] 
 **changedEmail** | **String**|  | [optional] 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

void (empty response body)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getApiAuthenticationDevManageInfo**
> InfoResponse getApiAuthenticationDevManageInfo(acceptLanguage)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getApiAuthenticationDevManageInfo(acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->getApiAuthenticationDevManageInfo: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**InfoResponse**](InfoResponse.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **postApiAuthenticationDevForgotPassword**
> postApiAuthenticationDevForgotPassword(acceptLanguage, forgotPasswordRequest)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final acceptLanguage = []; // List<String> | Language preference for the response.
final forgotPasswordRequest = ForgotPasswordRequest(); // ForgotPasswordRequest | 

try {
    api_instance.postApiAuthenticationDevForgotPassword(acceptLanguage, forgotPasswordRequest);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->postApiAuthenticationDevForgotPassword: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **forgotPasswordRequest** | [**ForgotPasswordRequest**](ForgotPasswordRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **postApiAuthenticationDevLogin**
> AccessTokenResponse postApiAuthenticationDevLogin(useCookies, useSessionCookies, acceptLanguage, loginRequest)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final useCookies = true; // bool | 
final useSessionCookies = true; // bool | 
final acceptLanguage = []; // List<String> | Language preference for the response.
final loginRequest = LoginRequest(); // LoginRequest | 

try {
    final result = api_instance.postApiAuthenticationDevLogin(useCookies, useSessionCookies, acceptLanguage, loginRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->postApiAuthenticationDevLogin: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **useCookies** | **bool**|  | [optional] 
 **useSessionCookies** | **bool**|  | [optional] 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **loginRequest** | [**LoginRequest**](LoginRequest.md)|  | [optional] 

### Return type

[**AccessTokenResponse**](AccessTokenResponse.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **postApiAuthenticationDevManage2fa**
> TwoFactorResponse postApiAuthenticationDevManage2fa(acceptLanguage, twoFactorRequest)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final acceptLanguage = []; // List<String> | Language preference for the response.
final twoFactorRequest = TwoFactorRequest(); // TwoFactorRequest | 

try {
    final result = api_instance.postApiAuthenticationDevManage2fa(acceptLanguage, twoFactorRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->postApiAuthenticationDevManage2fa: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **twoFactorRequest** | [**TwoFactorRequest**](TwoFactorRequest.md)|  | [optional] 

### Return type

[**TwoFactorResponse**](TwoFactorResponse.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **postApiAuthenticationDevManageInfo**
> InfoResponse postApiAuthenticationDevManageInfo(acceptLanguage, infoRequest)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final acceptLanguage = []; // List<String> | Language preference for the response.
final infoRequest = InfoRequest(); // InfoRequest | 

try {
    final result = api_instance.postApiAuthenticationDevManageInfo(acceptLanguage, infoRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->postApiAuthenticationDevManageInfo: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **infoRequest** | [**InfoRequest**](InfoRequest.md)|  | [optional] 

### Return type

[**InfoResponse**](InfoResponse.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **postApiAuthenticationDevRefresh**
> AccessTokenResponse postApiAuthenticationDevRefresh(acceptLanguage, refreshRequest)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final acceptLanguage = []; // List<String> | Language preference for the response.
final refreshRequest = RefreshRequest(); // RefreshRequest | 

try {
    final result = api_instance.postApiAuthenticationDevRefresh(acceptLanguage, refreshRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->postApiAuthenticationDevRefresh: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **refreshRequest** | [**RefreshRequest**](RefreshRequest.md)|  | [optional] 

### Return type

[**AccessTokenResponse**](AccessTokenResponse.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **postApiAuthenticationDevRegister**
> postApiAuthenticationDevRegister(acceptLanguage, registerRequest)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final acceptLanguage = []; // List<String> | Language preference for the response.
final registerRequest = RegisterRequest(); // RegisterRequest | 

try {
    api_instance.postApiAuthenticationDevRegister(acceptLanguage, registerRequest);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->postApiAuthenticationDevRegister: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **registerRequest** | [**RegisterRequest**](RegisterRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **postApiAuthenticationDevResendConfirmationEmail**
> postApiAuthenticationDevResendConfirmationEmail(acceptLanguage, resendConfirmationEmailRequest)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final acceptLanguage = []; // List<String> | Language preference for the response.
final resendConfirmationEmailRequest = ResendConfirmationEmailRequest(); // ResendConfirmationEmailRequest | 

try {
    api_instance.postApiAuthenticationDevResendConfirmationEmail(acceptLanguage, resendConfirmationEmailRequest);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->postApiAuthenticationDevResendConfirmationEmail: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **resendConfirmationEmailRequest** | [**ResendConfirmationEmailRequest**](ResendConfirmationEmailRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **postApiAuthenticationDevResetPassword**
> postApiAuthenticationDevResetPassword(acceptLanguage, resetPasswordRequest)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = AuthenticationDevApi();
final acceptLanguage = []; // List<String> | Language preference for the response.
final resetPasswordRequest = ResetPasswordRequest(); // ResetPasswordRequest | 

try {
    api_instance.postApiAuthenticationDevResetPassword(acceptLanguage, resetPasswordRequest);
} catch (e) {
    print('Exception when calling AuthenticationDevApi->postApiAuthenticationDevResetPassword: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **resetPasswordRequest** | [**ResetPasswordRequest**](ResetPasswordRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

