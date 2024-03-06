//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

library openapi.api;

import 'dart:async';
import 'dart:convert';
import 'dart:io';

import 'package:collection/collection.dart';
import 'package:http/http.dart';
import 'package:intl/intl.dart';
import 'package:meta/meta.dart';

part 'api_client.dart';
part 'api_helper.dart';
part 'api_exception.dart';
part 'auth/authentication.dart';
part 'auth/api_key_auth.dart';
part 'auth/oauth.dart';
part 'auth/http_basic_auth.dart';
part 'auth/http_bearer_auth.dart';

part 'api/authentication_api.dart';
part 'api/authentication_dev_api.dart';
part 'api/brokers_api.dart';
part 'api/cars_api.dart';
part 'api/documents_api.dart';
part 'api/inspections_api.dart';
part 'api/lookups_api.dart';
part 'api/orders_api.dart';
part 'api/owners_api.dart';
part 'api/parking_slots_api.dart';
part 'api/releasing_api.dart';
part 'api/reports_api.dart';
part 'api/up_coming_events_api.dart';
part 'api/users_api.dart';

part 'model/access_token_response.dart';
part 'model/application_user_dto.dart';
part 'model/broker_dto.dart';
part 'model/broker_dto_user_details.dart';
part 'model/broker_vm.dart';
part 'model/car_brief_dto.dart';
part 'model/car_dto.dart';
part 'model/car_vm.dart';
part 'model/color_dto.dart';
part 'model/color_vm.dart';
part 'model/create_user_command.dart';
part 'model/document_brief_dto.dart';
part 'model/document_dto.dart';
part 'model/document_dto_file.dart';
part 'model/edit_broker_command.dart';
part 'model/edit_car_command.dart';
part 'model/edit_parking_slot_command.dart';
part 'model/edit_release_command.dart';
part 'model/file_dto.dart';
part 'model/forgot_password_request.dart';
part 'model/http_validation_problem_details.dart';
part 'model/info_request.dart';
part 'model/info_response.dart';
part 'model/inspection_brief_dto.dart';
part 'model/inspection_dto.dart';
part 'model/inspection_dto_car.dart';
part 'model/login_request.dart';
part 'model/login_request2.dart';
part 'model/make_dto.dart';
part 'model/make_vm.dart';
part 'model/model_dto.dart';
part 'model/model_vm.dart';
part 'model/order_vm.dart';
part 'model/overall_dto.dart';
part 'model/paginated_list_of_application_user_dto.dart';
part 'model/paginated_list_of_car_brief_dto.dart';
part 'model/paginated_list_of_document_dto.dart';
part 'model/paginated_list_of_inspection_dto.dart';
part 'model/paginated_list_of_parking_slot_dto.dart';
part 'model/parking_slot_dto.dart';
part 'model/problem_details.dart';
part 'model/refresh_request.dart';
part 'model/register_request.dart';
part 'model/release_dto.dart';
part 'model/release_vm.dart';
part 'model/resend_confirmation_email_request.dart';
part 'model/reset_password_request.dart';
part 'model/role_dto.dart';
part 'model/role_vm.dart';
part 'model/two_factor_request.dart';
part 'model/two_factor_response.dart';
part 'model/upcoming_event_dto.dart';
part 'model/upcoming_event_vm.dart';
part 'model/user_details_response.dart';


/// An [ApiClient] instance that uses the default values obtained from
/// the OpenAPI specification file.
var defaultApiClient = ApiClient();

const _delimiters = {'csv': ',', 'ssv': ' ', 'tsv': '\t', 'pipes': '|'};
const _dateEpochMarker = 'epoch';
const _deepEquality = DeepCollectionEquality();
final _dateFormatter = DateFormat('yyyy-MM-dd');
final _regList = RegExp(r'^List<(.*)>$');
final _regSet = RegExp(r'^Set<(.*)>$');
final _regMap = RegExp(r'^Map<String,(.*)>$');

bool _isEpochMarker(String? pattern) => pattern == _dateEpochMarker || pattern == '/$_dateEpochMarker/';
