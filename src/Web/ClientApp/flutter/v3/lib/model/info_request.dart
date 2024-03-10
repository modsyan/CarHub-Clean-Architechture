//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class InfoRequest {
  /// Returns a new [InfoRequest] instance.
  InfoRequest({
    this.newEmail,
    this.newPassword,
    this.oldPassword,
  });

  String? newEmail;

  String? newPassword;

  String? oldPassword;

  @override
  bool operator ==(Object other) => identical(this, other) || other is InfoRequest &&
    other.newEmail == newEmail &&
    other.newPassword == newPassword &&
    other.oldPassword == oldPassword;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (newEmail == null ? 0 : newEmail!.hashCode) +
    (newPassword == null ? 0 : newPassword!.hashCode) +
    (oldPassword == null ? 0 : oldPassword!.hashCode);

  @override
  String toString() => 'InfoRequest[newEmail=$newEmail, newPassword=$newPassword, oldPassword=$oldPassword]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.newEmail != null) {
      json[r'newEmail'] = this.newEmail;
    } else {
      json[r'newEmail'] = null;
    }
    if (this.newPassword != null) {
      json[r'newPassword'] = this.newPassword;
    } else {
      json[r'newPassword'] = null;
    }
    if (this.oldPassword != null) {
      json[r'oldPassword'] = this.oldPassword;
    } else {
      json[r'oldPassword'] = null;
    }
    return json;
  }

  /// Returns a new [InfoRequest] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static InfoRequest? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "InfoRequest[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "InfoRequest[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return InfoRequest(
        newEmail: mapValueOfType<String>(json, r'newEmail'),
        newPassword: mapValueOfType<String>(json, r'newPassword'),
        oldPassword: mapValueOfType<String>(json, r'oldPassword'),
      );
    }
    return null;
  }

  static List<InfoRequest> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <InfoRequest>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = InfoRequest.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, InfoRequest> mapFromJson(dynamic json) {
    final map = <String, InfoRequest>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = InfoRequest.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of InfoRequest-objects as value to a dart map
  static Map<String, List<InfoRequest>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<InfoRequest>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = InfoRequest.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

