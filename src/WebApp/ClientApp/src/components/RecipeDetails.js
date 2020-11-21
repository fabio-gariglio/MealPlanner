import React, { useState, useEffect } from 'react';
import { useParams } from "react-router-dom";
import { Container, Row, Col } from 'react-bootstrap';
import axios from 'axios';

import { RecipeIngredientList } from './RecipeIngredientList';
import { RecipeInstructionList } from './RecipeInstructionList';

export function RecipeDetails() {

    const [recipeDetails, setRecipeDetails] = useState({});
    const { recipeId } = useParams();
    
    useEffect(() => {
        async function fetchRecipeDetails() {
            const result = await axios(`/api/recipes/${recipeId}`);
            setRecipeDetails(result.data);
        };
        fetchRecipeDetails();
    }, [recipeId]);

    function renderRecipeDetails() {
        return (
            <Container>
                <Row>
                    <Col><h1>{recipeDetails.name}</h1></Col>
                </Row>
                <Row>
                    <Col lg={4} md={12}>
                        <RecipeIngredientList ingredients={recipeDetails.ingredients} />
                    </Col>
                    <Col lg={8} md={12}>
                        <RecipeInstructionList instructions={recipeDetails.instructions} />
                    </Col>
                </Row>
            </Container>
        );
    };

    return !!recipeDetails.id
        ? renderRecipeDetails()
        : <p>Loading...</p>;

}