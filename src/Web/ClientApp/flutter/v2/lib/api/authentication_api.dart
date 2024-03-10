//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class AuthenticationApi {
  AuthenticationApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'GET /api/Authentication/confirm-email' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] userId (required):
  ///
  /// * [String] code (required):
  ///
  /// * [String] changedEmail:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> confirmEmailWithHttpInfo(String userId, String code, { String? changedEmail, List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Authentication/confirm-email';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

      queryParams.addAll(_queryParams('', 'userId', userId));
      queryParams.addAll(_queryParams('', 'code', code));
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
  /// * [String] userId (required):
  ///
  /// * [String] code (required):
  ///
  /// * [String] changedEmail:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<void> confirmEmail(String userId, String code, { String? changedEmail, List<String>? acceptLanguage, }) async {
    final response = await confirmEmailWithHttpInfo(userId, code,  changedEmail: changedEmail, acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/Authentication/forgot-password' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [ForgotPasswordRequest] forgotPasswordRequest (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> forgotPasswordWithHttpInfo(ForgotPasswordRequest forgotPasswordRequest, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Authentication/forgot-password';

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
  /// * [ForgotPasswordRequest] forgotPasswordRequest (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<void> forgotPassword(ForgotPasswordRequest forgotPasswordRequest, { List<String>? acceptLanguage, }) async {
    final response = await forgotPasswordWithHttpInfo(forgotPasswordRequest,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/Authentication/login' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [LoginRequest2] loginRequest2 (required):
  ///
  /// * [bool] useCookies:
  ///
  /// * [bool] useSessionCookies:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> postApiAuthenticationLoginWithHttpInfo(LoginRequest2 loginRequest2, { bool? useCookies, bool? useSessionCookies, List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Authentication/login';

    // ignore: prefer_final_locals
    Object? postBody = loginRequest2;

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
  /// * [LoginRequest2] loginRequest2 (required):
  ///
  /// * [bool] useCookies:
  ///
  /// * [bool] useSessionCookies:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<AccessTokenResponse?> postApiAuthenticationLogin(LoginRequest2 loginRequest2, { bool? useCookies, bool? useSessionCookies, List<String>? acceptLanguage, }) async {
    final response = await postApiAuthenticationLoginWithHttpInfo(loginRequest2,  useCookies: useCookies, useSessionCookies: useSessionCookies, acceptLanguage: acceptLanguage, );
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

  /// Performs an HTTP 'POST /api/Authentication/refresh-token' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [RefreshRequest] refreshRequest (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> refreshTokenWithHttpInfo(RefreshRequest refreshRequest, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Authentication/refresh-token';

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
  /// * [RefreshRequest] refreshRequest (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<AccessTokenResponse?> refreshToken(RefreshRequest refreshRequest, { List<String>? acceptLanguage, }) async {
    final response = await refreshTokenWithHttpInfo(refreshRequest,  acceptLanguage: acceptLanguage, );
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

  /// Performs an HTTP 'POST /api/Authentication/resend-confirmation-email' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [ResendConfirmationEmailRequest] resendConfirmationEmailRequest (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> resendConfirmationEmailWithHttpInfo(ResendConfirmationEmailRequest resendConfirmationEmailRequest, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Authentication/resend-confirmation-email';

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
  /// * [ResendConfirmationEmailRequest] resendConfirmationEmailRequest (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<void> resendConfirmationEmail(ResendConfirmationEmailRequest resendConfirmationEmailRequest, { List<String>? acceptLanguage, }) async {
    final response = await resendConfirmationEmailWithHttpInfo(resendConfirmationEmailRequest,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }

  /// Performs an HTTP 'POST /api/Authentication/reset-password' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [ResetPasswordRequest] resetPasswordRequest (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> resetPasswordWithHttpInfo(ResetPasswordRequest resetPasswordRequest, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Authentication/reset-password';

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
  /// * [ResetPasswordRequest] resetPasswordRequest (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<void> resetPassword(ResetPasswordRequest resetPasswordRequest, { List<String>? acceptLanguage, }) async {
    final response = await resetPasswordWithHttpInfo(resetPasswordRequest,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
  }
}
