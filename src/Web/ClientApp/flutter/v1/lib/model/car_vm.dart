//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class CarVm {
  /// Returns a new [CarVm] instance.
  CarVm({
    this.cars = const [],
    this.currentPage,
    this.pageSize,
    this.totalCount,
    this.totalPages,
  });

  List<CarBriefDto> cars;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? currentPage;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? pageSize;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? totalCount;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? totalPages;

  @override
  bool operator ==(Object other) => identical(this, other) || other is CarVm &&
    _deepEquality.equals(other.cars, cars) &&
    other.currentPage == currentPage &&
    other.pageSize == pageSize &&
    other.totalCount == totalCount &&
    other.totalPages == totalPages;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (cars.hashCode) +
    (currentPage == null ? 0 : currentPage!.hashCode) +
    (pageSize == null ? 0 : pageSize!.hashCode) +
    (totalCount == null ? 0 : totalCount!.hashCode) +
    (totalPages == null ? 0 : totalPages!.hashCode);

  @override
  String toString() => 'CarVm[cars=$cars, currentPage=$currentPage, pageSize=$pageSize, totalCount=$totalCount, totalPages=$totalPages]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'cars'] = this.cars;
    if (this.currentPage != null) {
      json[r'currentPage'] = this.currentPage;
    } else {
      json[r'currentPage'] = null;
    }
    if (this.pageSize != null) {
      json[r'pageSize'] = this.pageSize;
    } else {
      json[r'pageSize'] = null;
    }
    if (this.totalCount != null) {
      json[r'totalCount'] = this.totalCount;
    } else {
      json[r'totalCount'] = null;
    }
    if (this.totalPages != null) {
      json[r'totalPages'] = this.totalPages;
    } else {
      json[r'totalPages'] = null;
    }
    return json;
  }

  /// Returns a new [CarVm] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static CarVm? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "CarVm[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "CarVm[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return CarVm(
        cars: CarBriefDto.listFromJson(json[r'cars']),
        currentPage: mapValueOfType<int>(json, r'currentPage'),
        pageSize: mapValueOfType<int>(json, r'pageSize'),
        totalCount: mapValueOfType<int>(json, r'totalCount'),
        totalPages: mapValueOfType<int>(json, r'totalPages'),
      );
    }
    return null;
  }

  static List<CarVm> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <CarVm>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = CarVm.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, CarVm> mapFromJson(dynamic json) {
    final map = <String, CarVm>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = CarVm.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of CarVm-objects as value to a dart map
  static Map<String, List<CarVm>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<CarVm>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = CarVm.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

