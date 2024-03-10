//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class AuthenticationDevApi {
  AuthenticationDevApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'GET /api/AuthenticationDev/confirmEmail' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] userId:
  ///
  /// * [String] code:
  ///
  /// * [String] changedEmail:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getApiAuthenticationDevConfirmEmailWithHttpInfo({ String? userId, String? code, String? changedEmail, List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/confirmEmail';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (userId != null) {
      queryParams.addAll(_queryParams('', 'userId', userId));
    }
    if (code != null) {
      queryParams.addAll(_queryParams('', 'code', code));
    }
    if (changedEmail != null) {
      queryParams.addAll(_queryParams('', 'changedEmail', changedEmail));
    }

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'GET',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [String] userId:
  ///
  /// * [String] code:
  ///
  /// * [String] changedEmail:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<void> getApiAuthenticationDevConfirmEmail({ String? userId, String? code, String? changedEmail, List<String>? acceptLanguage, }) async {
    final response = await getApiAuthenticationDevConfirmEmailWithHttpInfo( userId: userId, code: code, changedEmail: changedEmail, acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'GET /api/AuthenticationDev/manage/info' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getApiAuthenticationDevManageInfoWithHttpInfo({ List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/manage/info';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'GET',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<InfoResponse?> getApiAuthenticationDevManageInfo({ List<String>? acceptLanguage, }) async {
    final response = await getApiAuthenticationDevManageInfoWithHttpInfo( acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'InfoResponse',) as InfoResponse;
    
    }
    return null;
  }

  /// Performs an HTTP 'POST /api/AuthenticationDev/forgotPassword' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [ForgotPasswordRequest] forgotPasswordRequest:
  Future<Response> postApiAuthenticationDevForgotPasswordWithHttpInfo({ List<String>? acceptLanguage, ForgotPasswordRequest? forgotPasswordRequest, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/forgotPassword';

    // ignore: prefer_final_locals
    Object? postBody = forgotPasswordRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [ForgotPasswordRequest] forgotPasswordRequest:
  Future<void> postApiAuthenticationDevForgotPassword({ List<String>? acceptLanguage, ForgotPasswordRequest? forgotPasswordRequest, }) async {
    final response = await postApiAuthenticationDevForgotPasswordWithHttpInfo( acceptLanguage: acceptLanguage, forgotPasswordRequest: forgotPasswordRequest, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/AuthenticationDev/login' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [bool] useCookies:
  ///
  /// * [bool] useSessionCookies:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [LoginRequest] loginRequest:
  Future<Response> postApiAuthenticationDevLoginWithHttpInfo({ bool? useCookies, bool? useSessionCookies, List<String>? acceptLanguage, LoginRequest? loginRequest, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/login';

    // ignore: prefer_final_locals
    Object? postBody = loginRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (useCookies != null) {
      queryParams.addAll(_queryParams('', 'useCookies', useCookies));
    }
    if (useSessionCookies != null) {
      queryParams.addAll(_queryParams('', 'useSessionCookies', useSessionCookies));
    }

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [bool] useCookies:
  ///
  /// * [bool] useSessionCookies:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [LoginRequest] loginRequest:
  Future<AccessTokenResponse?> postApiAuthenticationDevLogin({ bool? useCookies, bool? useSessionCookies, List<String>? acceptLanguage, LoginRequest? loginRequest, }) async {
    final response = await postApiAuthenticationDevLoginWithHttpInfo( useCookies: useCookies, useSessionCookies: useSessionCookies, acceptLanguage: acceptLanguage, loginRequest: loginRequest, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'AccessTokenResponse',) as AccessTokenResponse;
    
    }
    return null;
  }

  /// Performs an HTTP 'POST /api/AuthenticationDev/manage/2fa' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [TwoFactorRequest] twoFactorRequest:
  Future<Response> postApiAuthenticationDevManage2faWithHttpInfo({ List<String>? acceptLanguage, TwoFactorRequest? twoFactorRequest, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/manage/2fa';

    // ignore: prefer_final_locals
    Object? postBody = twoFactorRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [TwoFactorRequest] twoFactorRequest:
  Future<TwoFactorResponse?> postApiAuthenticationDevManage2fa({ List<String>? acceptLanguage, TwoFactorRequest? twoFactorRequest, }) async {
    final response = await postApiAuthenticationDevManage2faWithHttpInfo( acceptLanguage: acceptLanguage, twoFactorRequest: twoFactorRequest, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'TwoFactorResponse',) as TwoFactorResponse;
    
    }
    return null;
  }

  /// Performs an HTTP 'POST /api/AuthenticationDev/manage/info' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [InfoRequest] infoRequest:
  Future<Response> postApiAuthenticationDevManageInfoWithHttpInfo({ List<String>? acceptLanguage, InfoRequest? infoRequest, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/manage/info';

    // ignore: prefer_final_locals
    Object? postBody = infoRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [InfoRequest] infoRequest:
  Future<InfoResponse?> postApiAuthenticationDevManageInfo({ List<String>? acceptLanguage, InfoRequest? infoRequest, }) async {
    final response = await postApiAuthenticationDevManageInfoWithHttpInfo( acceptLanguage: acceptLanguage, infoRequest: infoRequest, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'InfoResponse',) as InfoResponse;
    
    }
    return null;
  }

  /// Performs an HTTP 'POST /api/AuthenticationDev/refresh' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [RefreshRequest] refreshRequest:
  Future<Response> postApiAuthenticationDevRefreshWithHttpInfo({ List<String>? acceptLanguage, RefreshRequest? refreshRequest, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/refresh';

    // ignore: prefer_final_locals
    Object? postBody = refreshRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [RefreshRequest] refreshRequest:
  Future<AccessTokenResponse?> postApiAuthenticationDevRefresh({ List<String>? acceptLanguage, RefreshRequest? refreshRequest, }) async {
    final response = await postApiAuthenticationDevRefreshWithHttpInfo( acceptLanguage: acceptLanguage, refreshRequest: refreshRequest, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'AccessTokenResponse',) as AccessTokenResponse;
    
    }
    return null;
  }

  /// Performs an HTTP 'POST /api/AuthenticationDev/register' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [RegisterRequest] registerRequest:
  Future<Response> postApiAuthenticationDevRegisterWithHttpInfo({ List<String>? acceptLanguage, RegisterRequest? registerRequest, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/register';

    // ignore: prefer_final_locals
    Object? postBody = registerRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [RegisterRequest] registerRequest:
  Future<void> postApiAuthenticationDevRegister({ List<String>? acceptLanguage, RegisterRequest? registerRequest, }) async {
    final response = await postApiAuthenticationDevRegisterWithHttpInfo( acceptLanguage: acceptLanguage, registerRequest: registerRequest, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/AuthenticationDev/resendConfirmationEmail' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [ResendConfirmationEmailRequest] resendConfirmationEmailRequest:
  Future<Response> postApiAuthenticationDevResendConfirmationEmailWithHttpInfo({ List<String>? acceptLanguage, ResendConfirmationEmailRequest? resendConfirmationEmailRequest, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/resendConfirmationEmail';

    // ignore: prefer_final_locals
    Object? postBody = resendConfirmationEmailRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [ResendConfirmationEmailRequest] resendConfirmationEmailRequest:
  Future<void> postApiAuthenticationDevResendConfirmationEmail({ List<String>? acceptLanguage, ResendConfirmationEmailRequest? resendConfirmationEmailRequest, }) async {
    final response = await postApiAuthenticationDevResendConfirmationEmailWithHttpInfo( acceptLanguage: acceptLanguage, resendConfirmationEmailRequest: resendConfirmationEmailRequest, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/AuthenticationDev/resetPassword' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [ResetPasswordRequest] resetPasswordRequest:
  Future<Response> postApiAuthenticationDevResetPasswordWithHttpInfo({ List<String>? acceptLanguage, ResetPasswordRequest? resetPasswordRequest, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/AuthenticationDev/resetPassword';

    // ignore: prefer_final_locals
    Object? postBody = resetPasswordRequest;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [ResetPasswordRequest] resetPasswordRequest:
  Future<void> postApiAuthenticationDevResetPassword({ List<String>? acceptLanguage, ResetPasswordRequest? resetPasswordRequest, }) async {
    final response = await postApiAuthenticationDevResetPasswordWithHttpInfo( acceptLanguage: acceptLanguage, resetPasswordRequest: resetPasswordRequest, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
