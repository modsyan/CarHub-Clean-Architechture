//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class UpComingEventsApi {
  UpComingEventsApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'GET /api/UpComingEvents/{date}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [DateTime] date (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getUpcomingEventDetailsWithHttpInfo(DateTime date, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/UpComingEvents/{date}'
      .replaceAll('{date}', date.toString());

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
  /// * [DateTime] date (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<UpcomingEventVm?> getUpcomingEventDetails(DateTime date, { List<String>? acceptLanguage, }) async {
    final response = await getUpcomingEventDetailsWithHttpInfo(date,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'UpcomingEventVm',) as UpcomingEventVm;
    
    }
    return null;
  }

  /// Performs an HTTP 'GET /api/UpComingEvents' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [DateTime] startDate:
  ///
  /// * [DateTime] endDate:
  ///
  /// * [int] pageNumber:
  ///
  /// * [int] pageSize:
  ///
  /// * [String] sortOrder:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getUpcomingEventsWithHttpInfo({ DateTime? startDate, DateTime? endDate, int? pageNumber, int? pageSize, String? sortOrder, List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/UpComingEvents';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (startDate != null) {
      queryParams.addAll(_queryParams('', 'startDate', startDate));
    }
    if (endDate != null) {
      queryParams.addAll(_queryParams('', 'endDate', endDate));
    }
    if (pageNumber != null) {
      queryParams.addAll(_queryParams('', 'pageNumber', pageNumber));
    }
    if (pageSize != null) {
      queryParams.addAll(_queryParams('', 'pageSize', pageSize));
    }
    if (sortOrder != null) {
      queryParams.addAll(_queryParams('', 'sortOrder', sortOrder));
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
  /// * [DateTime] startDate:
  ///
  /// * [DateTime] endDate:
  ///
  /// * [int] pageNumber:
  ///
  /// * [int] pageSize:
  ///
  /// * [String] sortOrder:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<UpcomingEventVm?> getUpcomingEvents({ DateTime? startDate, DateTime? endDate, int? pageNumber, int? pageSize, String? sortOrder, List<String>? acceptLanguage, }) async {
    final response = await getUpcomingEventsWithHttpInfo( startDate: startDate, endDate: endDate, pageNumber: pageNumber, pageSize: pageSize, sortOrder: sortOrder, acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'UpcomingEventVm',) as UpcomingEventVm;
    
    }
    return null;
  }
}
