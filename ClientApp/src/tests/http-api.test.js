const axios = require("axios");

// override default axios adapter so that it ignores cors for server-side requests
axios.defaults.adapter = require("axios/lib/adapters/http");

let petOwner = null;
let pet = null;

const SERVER_URL = "http://localhost:5000";
test("Create a new pet owner via HTTP POST", async () => {
  // nothing to do yet
  const newOwner = { name: "test owner", emailAddress: "test@example.com" };
  const response = await axios.post(`${SERVER_URL}/api/petowners`, newOwner);
  petOwner = response.data;
  expect(response.status).toBe(201);
  expect(typeof response.data).toBe(typeof {});
  expect(typeof response.data.id).toBe(typeof 0);
  console.log(`Pet Owner created with id ${petOwner.id}`);
  // console.log(response.data);
});

test(`Update the pet owner via HTTP PUT`, async () => {
  const newName = "test owner 2";
  const newOwner = { ...petOwner, name: newName };
  const response = await axios.put(
    `${SERVER_URL}/api/petowners/${petOwner.id}`,
    newOwner
  );
  expect(response.status).toBe(200);
  expect(response.data.name).toBe(newName);
  console.log(`Pet Owner with id ${petOwner.id} name changed to ${newName}`);
  petOwner = response.data;
});

test(`Get the updated pet owner via HTTP GET`, async () => {
  const response = await axios.get(
    `${SERVER_URL}/api/petowners/${petOwner.id}`
  );
  expect(response.status).toBe(200);
  expect(response.data.id).toBe(petOwner.id);
  expect(typeof response.data).toBe(typeof {});
  console.log(`Pet Owner with id ${petOwner.id} successfully retrieved.`);
});

test(`Get all pet owners via HTTP GET`, async () => {
  const response = await axios.get(`${SERVER_URL}/api/petowners/`);
  expect(response.status).toBe(200);
  expect(typeof response.data).toBe(typeof []);
  // does the array contain the object? this is neat.
  expect(response.data).toEqual(expect.arrayContaining([petOwner]));
  console.log(`Pet Owner with id ${petOwner.id} successfully retrieved.`);
});

test("Get All pet owners via HTTP GET", async () => {
  // nothing to do yet
  const response = await axios.get(`${SERVER_URL}/api/petowners`);
  expect(response.status).toBe(200);
  expect(typeof response.data).toBe(typeof []);
});

/********************* Pets Tests! /**********************/
test("Create a new pet via HTTP POST", async () => {
  // nothing to do yet
  const newPet = {
    name: "Fido 1",
    breed: "Retriever",
    color: "Golden",
    petOwnerid: petOwner.id,
  };
  let response;
  try {
    response = await axios.post(`${SERVER_URL}/api/pets`, newPet);
  } catch (err) {
    console.log(err.response.data);
  }
  pet = response.data;
  expect(response.status).toBe(201);
  expect(typeof response.data).toBe(typeof {});
  expect(typeof response.data.id).toBe(typeof 0);
  expect(typeof response.data.petOwner.petCount).toBe(typeof 1);
  expect(response.data.petOwner.petCount).toBe(1);
  expect(response.data.checkedInAt).toBeNull();
  console.log(`Pet created with id ${pet.id} and owner ${petOwner.name}`);
});

test("Update the pet via HTTP PUT", async () => {
  const newName = "Fido II";
  const newPet = { ...pet, name: newName, color: "Black" };
  const response = await axios.put(`${SERVER_URL}/api/pets/${pet.id}`, newPet);
  expect(response.status).toBe(200);
  expect(response.data.name).toBe(newName);
  console.log(`Pet  with id ${pet.id} name changed to ${newName}`);
  pet = response.data;
});

test("Check in the pet via HTTP PUT", async () => {
  const response = await axios.put(`${SERVER_URL}/api/pets/${pet.id}/checkin`);
  expect(response.status).toBe(200);
  expect(response.data.name).toBe(pet.name);
  expect(typeof response.data.checkedInAt).toBe(typeof "");
  expect(response.data.checkedInAt.length).toBeGreaterThan(0);
  console.log(`Checked in pet with id ${pet.id} at ${pet.checkedInAt}`);
  pet = response.data;
});

test("Check out the pet via HTTP PUT", async () => {
  const response = await axios.put(`${SERVER_URL}/api/pets/${pet.id}/checkout`);
  expect(response.status).toBe(200);
  expect(response.data.name).toBe(pet.name);
  expect(response.data.checkedInAt).toBeNull();
  console.log(`Checked out pet with id ${pet.id}`);
  pet = response.data;
});

test("Delete the pet via HTTP DELETE", async () => {
  // nothing to do yet
  const response = await axios.delete(`${SERVER_URL}/api/pets/${pet.id}`);
  expect(response.status).toBe(204);
});

// Clean Up
test("Delete the pet owner via HTTP DELETE", async () => {
  // nothing to do yet
  const response = await axios.delete(
    `${SERVER_URL}/api/petowners/${petOwner.id}`
  );
  expect(response.status).toBe(204);
});
