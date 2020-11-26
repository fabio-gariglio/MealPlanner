import React, { useState, useEffect } from 'react';
import { Form, Button } from 'react-bootstrap';
import axios from 'axios';

export function RecipeCreator() {

  const [name, setName] = useState("");
  const [instructions, setInstructions] = useState("");
  const [ingredients, setIngredients] = useState("");

  function handleSubmit(change) {
    axios.post("/api/recipes", {
      name: name,
      instructions: instructions,
      ingredients: ingredients
    });
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group controlId="recipeForm.name">
        <Form.Label>Recipe Name</Form.Label>
        <Form.Control
          type="text"
          placeholder="Recipe Name"
          value={name}
          onChange={e => setName(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="recipeForm.ingredients">
        <Form.Label>Ingredients</Form.Label>
        <Form.Control
          as="textarea"
          placeholder="Ingredients"
          rows={3}
          value={ingredients}
          onChange={e => setIngredients(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="recipeForm.instructions">
        <Form.Label>Instructions</Form.Label>
        <Form.Control
          as="textarea"
          placeholder="Instructions"
          rows={3}
          value={instructions}
          onChange={e => setInstructions(e.target.value)}
        />
      </Form.Group>

      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
  );

};