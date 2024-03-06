//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class ParkingSlotDto {
  /// Returns a new [ParkingSlotDto] instance.
  ParkingSlotDto({
    this.id,
    this.title,
    this.description,
    this.isAvailable,
    this.capacity,
    this.cars = const [],
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
  String? title;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? description;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? isAvailable;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? capacity;

  List<CarBriefDto> cars;

  @override
  bool operator ==(Object other) => identical(this, other) || other is ParkingSlotDto &&
    other.id == id &&
    other.title == title &&
    other.description == description &&
    other.isAvailable == isAvailable &&
    other.capacity == capacity &&
    _deepEquality.equals(other.cars, cars);

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (title == null ? 0 : title!.hashCode) +
    (description == null ? 0 : description!.hashCode) +
    (isAvailable == null ? 0 : isAvailable!.hashCode) +
    (capacity == null ? 0 : capacity!.hashCode) +
    (cars.hashCode);

  @override
  String toString() => 'ParkingSlotDto[id=$id, title=$title, description=$description, isAvailable=$isAvailable, capacity=$capacity, cars=$cars]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.title != null) {
      json[r'title'] = this.title;
    } else {
      json[r'title'] = null;
    }
    if (this.description != null) {
      json[r'description'] = this.description;
    } else {
      json[r'description'] = null;
    }
    if (this.isAvailable != null) {
      json[r'isAvailable'] = this.isAvailable;
    } else {
      json[r'isAvailable'] = null;
    }
    if (this.capacity != null) {
      json[r'capacity'] = this.capacity;
    } else {
      json[r'capacity'] = null;
    }
      json[r'cars'] = this.cars;
    return json;
  }

  /// Returns a new [ParkingSlotDto] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static ParkingSlotDto? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "ParkingSlotDto[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "ParkingSlotDto[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return ParkingSlotDto(
        id: mapValueOfType<int>(json, r'id'),
        title: mapValueOfType<String>(json, r'title'),
        description: mapValueOfType<String>(json, r'description'),
        isAvailable: mapValueOfType<bool>(json, r'isAvailable'),
        capacity: mapValueOfType<int>(json, r'capacity'),
        cars: CarBriefDto.listFromJson(json[r'cars']),
      );
    }
    return null;
  }

  static List<ParkingSlotDto> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <ParkingSlotDto>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = ParkingSlotDto.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, ParkingSlotDto> mapFromJson(dynamic json) {
    final map = <String, ParkingSlotDto>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = ParkingSlotDto.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of ParkingSlotDto-objects as value to a dart map
  static Map<String, List<ParkingSlotDto>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<ParkingSlotDto>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = ParkingSlotDto.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

