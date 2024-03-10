//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class ColorDto {
  /// Returns a new [ColorDto] instance.
  ColorDto({
    this.id,
    this.localizedName,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? id;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? localizedName;

  @override
  bool operator ==(Object other) => identical(this, other) || other is ColorDto &&
    other.id == id &&
    other.localizedName == localizedName;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (localizedName == null ? 0 : localizedName!.hashCode);

  @override
  String toString() => 'ColorDto[id=$id, localizedName=$localizedName]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.localizedName != null) {
      json[r'localizedName'] = this.localizedName;
    } else {
      json[r'localizedName'] = null;
    }
    return json;
  }

  /// Returns a new [ColorDto] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static ColorDto? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "ColorDto[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "ColorDto[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return ColorDto(
        id: mapValueOfType<int>(json, r'id'),
        localizedName: mapValueOfType<String>(json, r'localizedName'),
      );
    }
    return null;
  }

  static List<ColorDto> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <ColorDto>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = ColorDto.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, ColorDto> mapFromJson(dynamic json) {
    final map = <String, ColorDto>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = ColorDto.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of ColorDto-objects as value to a dart map
  static Map<String, List<ColorDto>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<ColorDto>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = ColorDto.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

