//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class ResendConfirmationEmailRequest {
  /// Returns a new [ResendConfirmationEmailRequest] instance.
  ResendConfirmationEmailRequest({
    this.email,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? email;

  @override
  bool operator ==(Object other) => identical(this, other) || other is ResendConfirmationEmailRequest &&
    other.email == email;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (email == null ? 0 : email!.hashCode);

  @override
  String toString() => 'ResendConfirmationEmailRequest[email=$email]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.email != null) {
      json[r'email'] = this.email;
    } else {
      json[r'email'] = null;
    }
    return json;
  }

  /// Returns a new [ResendConfirmationEmailRequest] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static ResendConfirmationEmailRequest? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "ResendConfirmationEmailRequest[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "ResendConfirmationEmailRequest[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return ResendConfirmationEmailRequest(
        email: mapValueOfType<String>(json, r'email'),
      );
    }
    return null;
  }

  static List<ResendConfirmationEmailRequest> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <ResendConfirmationEmailRequest>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = ResendConfirmationEmailRequest.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, ResendConfirmationEmailRequest> mapFromJson(dynamic json) {
    final map = <String, ResendConfirmationEmailRequest>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = ResendConfirmationEmailRequest.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of ResendConfirmationEmailRequest-objects as value to a dart map
  static Map<String, List<ResendConfirmationEmailRequest>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<ResendConfirmationEmailRequest>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = ResendConfirmationEmailRequest.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

