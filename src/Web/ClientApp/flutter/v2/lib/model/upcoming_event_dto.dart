//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class UpcomingEventDto {
  /// Returns a new [UpcomingEventDto] instance.
  UpcomingEventDto({
    this.car,
    this.type,
    this.date,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  CarBriefDto? car;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? type;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  DateTime? date;

  @override
  bool operator ==(Object other) => identical(this, other) || other is UpcomingEventDto &&
    other.car == car &&
    other.type == type &&
    other.date == date;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (car == null ? 0 : car!.hashCode) +
    (type == null ? 0 : type!.hashCode) +
    (date == null ? 0 : date!.hashCode);

  @override
  String toString() => 'UpcomingEventDto[car=$car, type=$type, date=$date]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.car != null) {
      json[r'car'] = this.car;
    } else {
      json[r'car'] = null;
    }
    if (this.type != null) {
      json[r'type'] = this.type;
    } else {
      json[r'type'] = null;
    }
    if (this.date != null) {
      json[r'date'] = this.date!.toUtc().toIso8601String();
    } else {
      json[r'date'] = null;
    }
    return json;
  }

  /// Returns a new [UpcomingEventDto] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static UpcomingEventDto? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "UpcomingEventDto[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "UpcomingEventDto[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return UpcomingEventDto(
        car: CarBriefDto.fromJson(json[r'car']),
        type: mapValueOfType<String>(json, r'type'),
        date: mapDateTime(json, r'date', r''),
      );
    }
    return null;
  }

  static List<UpcomingEventDto> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <UpcomingEventDto>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = UpcomingEventDto.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, UpcomingEventDto> mapFromJson(dynamic json) {
    final map = <String, UpcomingEventDto>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = UpcomingEventDto.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of UpcomingEventDto-objects as value to a dart map
  static Map<String, List<UpcomingEventDto>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<UpcomingEventDto>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = UpcomingEventDto.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

