//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class CarDto {
  /// Returns a new [CarDto] instance.
  CarDto({
    this.id,
    this.userId,
    this.make,
    this.model,
    this.year,
    this.color,
    this.engineSerialNumber,
    this.inspections = const [],
    this.documents = const [],
    this.owner,
    this.status,
    this.isReleased,
    this.release,
    this.ownerDetails,
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
  String? userId;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? make;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? model;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? year;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? color;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? engineSerialNumber;

  List<InspectionBriefDto> inspections;

  List<DocumentBriefDto> documents;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  Object? owner;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? status;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? isReleased;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  ReleaseDto? release;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  UserDetailsResponse? ownerDetails;

  @override
  bool operator ==(Object other) => identical(this, other) || other is CarDto &&
    other.id == id &&
    other.userId == userId &&
    other.make == make &&
    other.model == model &&
    other.year == year &&
    other.color == color &&
    other.engineSerialNumber == engineSerialNumber &&
    _deepEquality.equals(other.inspections, inspections) &&
    _deepEquality.equals(other.documents, documents) &&
    other.owner == owner &&
    other.status == status &&
    other.isReleased == isReleased &&
    other.release == release &&
    other.ownerDetails == ownerDetails;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (userId == null ? 0 : userId!.hashCode) +
    (make == null ? 0 : make!.hashCode) +
    (model == null ? 0 : model!.hashCode) +
    (year == null ? 0 : year!.hashCode) +
    (color == null ? 0 : color!.hashCode) +
    (engineSerialNumber == null ? 0 : engineSerialNumber!.hashCode) +
    (inspections.hashCode) +
    (documents.hashCode) +
    (owner == null ? 0 : owner!.hashCode) +
    (status == null ? 0 : status!.hashCode) +
    (isReleased == null ? 0 : isReleased!.hashCode) +
    (release == null ? 0 : release!.hashCode) +
    (ownerDetails == null ? 0 : ownerDetails!.hashCode);

  @override
  String toString() => 'CarDto[id=$id, userId=$userId, make=$make, model=$model, year=$year, color=$color, engineSerialNumber=$engineSerialNumber, inspections=$inspections, documents=$documents, owner=$owner, status=$status, isReleased=$isReleased, release=$release, ownerDetails=$ownerDetails]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.userId != null) {
      json[r'userId'] = this.userId;
    } else {
      json[r'userId'] = null;
    }
    if (this.make != null) {
      json[r'make'] = this.make;
    } else {
      json[r'make'] = null;
    }
    if (this.model != null) {
      json[r'model'] = this.model;
    } else {
      json[r'model'] = null;
    }
    if (this.year != null) {
      json[r'year'] = this.year;
    } else {
      json[r'year'] = null;
    }
    if (this.color != null) {
      json[r'color'] = this.color;
    } else {
      json[r'color'] = null;
    }
    if (this.engineSerialNumber != null) {
      json[r'engineSerialNumber'] = this.engineSerialNumber;
    } else {
      json[r'engineSerialNumber'] = null;
    }
      json[r'inspections'] = this.inspections;
      json[r'documents'] = this.documents;
    if (this.owner != null) {
      json[r'owner'] = this.owner;
    } else {
      json[r'owner'] = null;
    }
    if (this.status != null) {
      json[r'status'] = this.status;
    } else {
      json[r'status'] = null;
    }
    if (this.isReleased != null) {
      json[r'isReleased'] = this.isReleased;
    } else {
      json[r'isReleased'] = null;
    }
    if (this.release != null) {
      json[r'release'] = this.release;
    } else {
      json[r'release'] = null;
    }
    if (this.ownerDetails != null) {
      json[r'ownerDetails'] = this.ownerDetails;
    } else {
      json[r'ownerDetails'] = null;
    }
    return json;
  }

  /// Returns a new [CarDto] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static CarDto? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "CarDto[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "CarDto[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return CarDto(
        id: mapValueOfType<String>(json, r'id'),
        userId: mapValueOfType<String>(json, r'userId'),
        make: mapValueOfType<String>(json, r'make'),
        model: mapValueOfType<String>(json, r'model'),
        year: mapValueOfType<String>(json, r'year'),
        color: mapValueOfType<String>(json, r'color'),
        engineSerialNumber: mapValueOfType<String>(json, r'engineSerialNumber'),
        inspections: InspectionBriefDto.listFromJson(json[r'inspections']),
        documents: DocumentBriefDto.listFromJson(json[r'documents']),
        owner: mapValueOfType<Object>(json, r'owner'),
        status: mapValueOfType<String>(json, r'status'),
        isReleased: mapValueOfType<bool>(json, r'isReleased'),
        release: ReleaseDto.fromJson(json[r'release']),
        ownerDetails: UserDetailsResponse.fromJson(json[r'ownerDetails']),
      );
    }
    return null;
  }

  static List<CarDto> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <CarDto>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = CarDto.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, CarDto> mapFromJson(dynamic json) {
    final map = <String, CarDto>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = CarDto.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of CarDto-objects as value to a dart map
  static Map<String, List<CarDto>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<CarDto>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = CarDto.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

