//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class ReleaseVm {
  /// Returns a new [ReleaseVm] instance.
  ReleaseVm({
    this.releases = const [],
  });

  List<ReleaseDto> releases;

  @override
  bool operator ==(Object other) => identical(this, other) || other is ReleaseVm &&
    _deepEquality.equals(other.releases, releases);

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (releases.hashCode);

  @override
  String toString() => 'ReleaseVm[releases=$releases]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'releases'] = this.releases;
    return json;
  }

  /// Returns a new [ReleaseVm] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static ReleaseVm? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "ReleaseVm[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "ReleaseVm[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return ReleaseVm(
        releases: ReleaseDto.listFromJson(json[r'releases']),
      );
    }
    return null;
  }

  static List<ReleaseVm> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <ReleaseVm>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = ReleaseVm.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, ReleaseVm> mapFromJson(dynamic json) {
    final map = <String, ReleaseVm>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = ReleaseVm.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of ReleaseVm-objects as value to a dart map
  static Map<String, List<ReleaseVm>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<ReleaseVm>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = ReleaseVm.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

