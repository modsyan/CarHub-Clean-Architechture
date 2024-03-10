//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class RoleVm {
  /// Returns a new [RoleVm] instance.
  RoleVm({
    this.roles = const [],
  });

  List<RoleDto> roles;

  @override
  bool operator ==(Object other) => identical(this, other) || other is RoleVm &&
    _deepEquality.equals(other.roles, roles);

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (roles.hashCode);

  @override
  String toString() => 'RoleVm[roles=$roles]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'roles'] = this.roles;
    return json;
  }

  /// Returns a new [RoleVm] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static RoleVm? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "RoleVm[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "RoleVm[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return RoleVm(
        roles: RoleDto.listFromJson(json[r'roles']),
      );
    }
    return null;
  }

  static List<RoleVm> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <RoleVm>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = RoleVm.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, RoleVm> mapFromJson(dynamic json) {
    final map = <String, RoleVm>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = RoleVm.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of RoleVm-objects as value to a dart map
  static Map<String, List<RoleVm>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<RoleVm>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = RoleVm.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

