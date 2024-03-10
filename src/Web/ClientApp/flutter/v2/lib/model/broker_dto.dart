//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class BrokerDto {
  /// Returns a new [BrokerDto] instance.
  BrokerDto({
    this.id,
    this.userId,
    this.userDetails,
    this.cars = const [],
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? id;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? userId;

  BrokerDtoUserDetails? userDetails;

  List<CarBriefDto> cars;

  @override
  bool operator ==(Object other) => identical(this, other) || other is BrokerDto &&
    other.id == id &&
    other.userId == userId &&
    other.userDetails == userDetails &&
    _deepEquality.equals(other.cars, cars);

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (userId == null ? 0 : userId!.hashCode) +
    (userDetails == null ? 0 : userDetails!.hashCode) +
    (cars.hashCode);

  @override
  String toString() => 'BrokerDto[id=$id, userId=$userId, userDetails=$userDetails, cars=$cars]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.userId != null) {
      json[r'userId'] = this.userId;
    } else {
      json[r'userId'] = null;
    }
    if (this.userDetails != null) {
      json[r'userDetails'] = this.userDetails;
    } else {
      json[r'userDetails'] = null;
    }
      json[r'cars'] = this.cars;
    return json;
  }

  /// Returns a new [BrokerDto] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static BrokerDto? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "BrokerDto[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "BrokerDto[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return BrokerDto(
        id: mapValueOfType<String>(json, r'id'),
        userId: mapValueOfType<String>(json, r'userId'),
        userDetails: BrokerDtoUserDetails.fromJson(json[r'userDetails']),
        cars: CarBriefDto.listFromJson(json[r'cars']),
      );
    }
    return null;
  }

  static List<BrokerDto> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <BrokerDto>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = BrokerDto.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, BrokerDto> mapFromJson(dynamic json) {
    final map = <String, BrokerDto>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = BrokerDto.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of BrokerDto-objects as value to a dart map
  static Map<String, List<BrokerDto>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<BrokerDto>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = BrokerDto.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

