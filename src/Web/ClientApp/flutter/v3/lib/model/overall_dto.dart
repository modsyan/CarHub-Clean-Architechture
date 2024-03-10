//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class OverallDto {
  /// Returns a new [OverallDto] instance.
  OverallDto({
    this.enteredCarsToday,
    this.enteredCarsThisMonth,
    this.enteredCarsThisYear,
    this.totalCars,
    this.topBrokers = const [],
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? enteredCarsToday;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? enteredCarsThisMonth;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? enteredCarsThisYear;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? totalCars;

  List<BrokerDto> topBrokers;

  @override
  bool operator ==(Object other) => identical(this, other) || other is OverallDto &&
    other.enteredCarsToday == enteredCarsToday &&
    other.enteredCarsThisMonth == enteredCarsThisMonth &&
    other.enteredCarsThisYear == enteredCarsThisYear &&
    other.totalCars == totalCars &&
    _deepEquality.equals(other.topBrokers, topBrokers);

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (enteredCarsToday == null ? 0 : enteredCarsToday!.hashCode) +
    (enteredCarsThisMonth == null ? 0 : enteredCarsThisMonth!.hashCode) +
    (enteredCarsThisYear == null ? 0 : enteredCarsThisYear!.hashCode) +
    (totalCars == null ? 0 : totalCars!.hashCode) +
    (topBrokers.hashCode);

  @override
  String toString() => 'OverallDto[enteredCarsToday=$enteredCarsToday, enteredCarsThisMonth=$enteredCarsThisMonth, enteredCarsThisYear=$enteredCarsThisYear, totalCars=$totalCars, topBrokers=$topBrokers]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.enteredCarsToday != null) {
      json[r'enteredCarsToday'] = this.enteredCarsToday;
    } else {
      json[r'enteredCarsToday'] = null;
    }
    if (this.enteredCarsThisMonth != null) {
      json[r'enteredCarsThisMonth'] = this.enteredCarsThisMonth;
    } else {
      json[r'enteredCarsThisMonth'] = null;
    }
    if (this.enteredCarsThisYear != null) {
      json[r'enteredCarsThisYear'] = this.enteredCarsThisYear;
    } else {
      json[r'enteredCarsThisYear'] = null;
    }
    if (this.totalCars != null) {
      json[r'totalCars'] = this.totalCars;
    } else {
      json[r'totalCars'] = null;
    }
      json[r'topBrokers'] = this.topBrokers;
    return json;
  }

  /// Returns a new [OverallDto] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static OverallDto? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "OverallDto[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "OverallDto[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return OverallDto(
        enteredCarsToday: mapValueOfType<int>(json, r'enteredCarsToday'),
        enteredCarsThisMonth: mapValueOfType<int>(json, r'enteredCarsThisMonth'),
        enteredCarsThisYear: mapValueOfType<int>(json, r'enteredCarsThisYear'),
        totalCars: mapValueOfType<int>(json, r'totalCars'),
        topBrokers: BrokerDto.listFromJson(json[r'topBrokers']),
      );
    }
    return null;
  }

  static List<OverallDto> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <OverallDto>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = OverallDto.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, OverallDto> mapFromJson(dynamic json) {
    final map = <String, OverallDto>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = OverallDto.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of OverallDto-objects as value to a dart map
  static Map<String, List<OverallDto>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<OverallDto>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = OverallDto.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

