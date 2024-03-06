//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class ReleaseDto {
  /// Returns a new [ReleaseDto] instance.
  ReleaseDto({
    this.id,
    this.releaseDate,
    this.car,
    this.documents = const [],
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
  DateTime? releaseDate;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  CarBriefDto? car;

  List<String> documents;

  @override
  bool operator ==(Object other) => identical(this, other) || other is ReleaseDto &&
    other.id == id &&
    other.releaseDate == releaseDate &&
    other.car == car &&
    _deepEquality.equals(other.documents, documents);

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (releaseDate == null ? 0 : releaseDate!.hashCode) +
    (car == null ? 0 : car!.hashCode) +
    (documents.hashCode);

  @override
  String toString() => 'ReleaseDto[id=$id, releaseDate=$releaseDate, car=$car, documents=$documents]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.releaseDate != null) {
      json[r'releaseDate'] = this.releaseDate!.toUtc().toIso8601String();
    } else {
      json[r'releaseDate'] = null;
    }
    if (this.car != null) {
      json[r'car'] = this.car;
    } else {
      json[r'car'] = null;
    }
      json[r'documents'] = this.documents;
    return json;
  }

  /// Returns a new [ReleaseDto] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static ReleaseDto? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "ReleaseDto[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "ReleaseDto[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return ReleaseDto(
        id: mapValueOfType<String>(json, r'id'),
        releaseDate: mapDateTime(json, r'releaseDate', r''),
        car: CarBriefDto.fromJson(json[r'car']),
        documents: json[r'documents'] is Iterable
            ? (json[r'documents'] as Iterable).cast<String>().toList(growable: false)
            : const [],
      );
    }
    return null;
  }

  static List<ReleaseDto> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <ReleaseDto>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = ReleaseDto.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, ReleaseDto> mapFromJson(dynamic json) {
    final map = <String, ReleaseDto>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = ReleaseDto.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of ReleaseDto-objects as value to a dart map
  static Map<String, List<ReleaseDto>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<ReleaseDto>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = ReleaseDto.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

