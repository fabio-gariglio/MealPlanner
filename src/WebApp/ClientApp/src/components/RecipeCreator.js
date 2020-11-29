import React, { useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useHistory } from "react-router-dom";
import axios from "axios";

export function RecipeCreator() {

  let history = useHistory();
  const [name, setName] = useState("");
  const [instructionList, setInstructionList] = useState("");
  const [ingredientList, setIngredientList] = useState("");

  function handleClick() {
    axios.post("/api/recipes/import",
        {
          name: name,
          ingredientList: ingredientList,
          instructionList: instructionList
        })
      .then(response => {
        history.push(`/recipes/${response.data.id}`);
      })
      .catch(error =>
        console.error(error)
      );
  };

  return (
    <Form>
      <Form.Group controlId="recipeForm.name">
        <Form.Label>Recipe Name</Form.Label>
        <Form.Control
          type="text"
          placeholder="Recipe Name"
          value={name}
          onChange={e => setName(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="recipeForm.instructions">
        <Form.Label>Instructions</Form.Label>
        <Form.Control
          as="textarea"
          placeholder="Instructions"
          rows={6}
          value={instructionList}
          onChange={e => setInstructionList(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="recipeForm.ingredients">
        <Form.Label>Ingredients</Form.Label>
        <Form.Control
          as="textarea"
          placeholder="Ingredients"
          rows={6}
          value={ingredientList}
          onChange={e => setIngredientList(e.target.value)}
        />
      </Form.Group>

      <Button variant="primary" onClick={handleClick}>
        Submit
      </Button>
    </Form>
  );

};