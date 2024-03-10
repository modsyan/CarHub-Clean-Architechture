//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class HttpValidationProblemDetails {
  /// Returns a new [HttpValidationProblemDetails] instance.
  HttpValidationProblemDetails({
    this.type,
    this.title,
    this.status,
    this.detail,
    this.instance,
    this.errors = const {},
  });

  String? type;

  String? title;

  int? status;

  String? detail;

  String? instance;

  Map<String, List<String>> errors;

  @override
  bool operator ==(Object other) => identical(this, other) || other is HttpValidationProblemDetails &&
    other.type == type &&
    other.title == title &&
    other.status == status &&
    other.detail == detail &&
    other.instance == instance &&
    _deepEquality.equals(other.errors, errors);

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (type == null ? 0 : type!.hashCode) +
    (title == null ? 0 : title!.hashCode) +
    (status == null ? 0 : status!.hashCode) +
    (detail == null ? 0 : detail!.hashCode) +
    (instance == null ? 0 : instance!.hashCode) +
    (errors.hashCode);

  @override
  String toString() => 'HttpValidationProblemDetails[type=$type, title=$title, status=$status, detail=$detail, instance=$instance, errors=$errors]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.type != null) {
      json[r'type'] = this.type;
    } else {
      json[r'type'] = null;
    }
    if (this.title != null) {
      json[r'title'] = this.title;
    } else {
      json[r'title'] = null;
    }
    if (this.status != null) {
      json[r'status'] = this.status;
    } else {
      json[r'status'] = null;
    }
    if (this.detail != null) {
      json[r'detail'] = this.detail;
    } else {
      json[r'detail'] = null;
    }
    if (this.instance != null) {
      json[r'instance'] = this.instance;
    } else {
      json[r'instance'] = null;
    }
      json[r'errors'] = this.errors;
    return json;
  }

  /// Returns a new [HttpValidationProblemDetails] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static HttpValidationProblemDetails? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "HttpValidationProblemDetails[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "HttpValidationProblemDetails[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return HttpValidationProblemDetails(
        type: mapValueOfType<String>(json, r'type'),
        title: mapValueOfType<String>(json, r'title'),
        status: mapValueOfType<int>(json, r'status'),
        detail: mapValueOfType<String>(json, r'detail'),
        instance: mapValueOfType<String>(json, r'instance'),
        errors: json[r'errors'] == null
          ? const {}
            : mapCastOfType<String, List>(json, r'errors'),
      );
    }
    return null;
  }

  static List<HttpValidationProblemDetails> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <HttpValidationProblemDetails>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = HttpValidationProblemDetails.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, HttpValidationProblemDetails> mapFromJson(dynamic json) {
    final map = <String, HttpValidationProblemDetails>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = HttpValidationProblemDetails.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of HttpValidationProblemDetails-objects as value to a dart map
  static Map<String, List<HttpValidationProblemDetails>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<HttpValidationProblemDetails>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = HttpValidationProblemDetails.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

