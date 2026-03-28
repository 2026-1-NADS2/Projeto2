import { Router } from 'express'
import { pool } from './db.js'

const r = Router()

// =========================
// TESTE DE CONEXÃO
// =========================
r.get('/db/health', async (_, res) => {
    try {
        const [rows] = await pool.query('SELECT 1 AS db_ok')
        res.json({ ok: true, db: rows[0].db_ok })
    } catch {
        res.status(500).json({ ok: false, db: 'down' })
    }
})


// GET TODOS FORNECEDORES
r.get('/fornecedores', async (_, res) => {
    try {
        const [rows] = await pool.query(
            'SELECT id_fornecedor, razao_social, nome_fantasia, cnpj, email, telefone, senha, descricao, cidade, estado, cep FROM fornecedores ORDER BY id_fornecedor DESC'
        )
        res.json(rows)
    } catch {
        res.status(500).json({ error: 'Erro ao listar fornecedores' })
    }
})


// GET POR ID
r.get('/fornecedores/:id', async (req, res) => {
    const { id } = req.params
    try {
        const [rows] = await pool.query(
            'SELECT * FROM fornecedores WHERE id_fornecedor = ?',
            [id]
        )

        if (rows.length === 0) {
            return res.status(404).json({ error: 'Fornecedor não encontrado' })
            }

            res.json(rows[0])
    } catch {
        res.status(500).json({ error: 'Erro ao buscar fornecedor' })
    }
})

// POST
r.post('/fornecedores', async (req, res) => {
    const { razao_social, nome_fantasia, cnpj, email, telefone, senha, descricao, cidade, estado, cep } = req.body

    if (!razao_social || !email || !cnpj || !senha) {
        return res.status(400).json({ error: 'Campos obrigatórios faltando' })
    }

    try {
        const [result] = await pool.query(
            `INSERT INTO fornecedores (razao_social, nome_fantasia, cnpj, email, telefone, senha, descricao, cidade, estado, cep) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)`,
            [razao_social, nome_fantasia, cnpj, email, telefone, senha, descricao, cidade, estado, cep]
        )

        res.status(201).json({ id: result.insertId })

    } catch (err) {
        if (err.code === 'ER_DUP_ENTRY') {
            return res.status(409).json({ error: 'Email ou CNPJ já cadastrado' })
        }
        res.status(500).json({ error: 'Erro ao criar fornecedor' })
    }
})


// DELETE
r.delete('/fornecedores/:id', async (req, res) => {
    const { id } = req.params

    try {
        const [result] = await pool.query(
            'DELETE FROM fornecedores WHERE id_fornecedor = ?',
            [id]
        )

        if (result.affectedRows === 0) {
            return res.status(404).json({ error: 'Fornecedor não encontrado' })
        }

        res.json({ message: 'Fornecedor excluído com sucesso' })

    } catch {
        res.status(500).json({ error: 'Erro ao excluir fornecedor' })
    }
})

// PUT 
r.put('/fornecedores/:id', async (req, res) => {
    const { id } = req.params
    const { razao_social, nome_fantasia, cnpj, email, telefone, senha, descricao, cidade, estado, cep } = req.body

    if (!razao_social || !email) {
        return res.status(400).json({ error: 'Campos obrigatórios' })
    }

    try {
        const [result] = await pool.query(
            'UPDATE fornecedores SET razao_social = ?, nome_fantasia = ?, cnpj = ?, email = ?,  telefone = ?, senha = ?, descricao = ?, cidade = ?, estado = ?, cep = ? WHERE id_fornecedor = ?',
            [razao_social, nome_fantasia, cnpj, email, telefone, senha, descricao, cidade, estado, cep, id]
        )

        if (result.affectedRows === 0) {
            return res.status(404).json({ error: 'Fornecedor não encontrado' })
        }

        const [rows] = await pool.query(
            'SELECT * FROM fornecedores WHERE id_fornecedor = ?',
            [id]
        )

        res.json(rows[0])

    } catch (err) {
        if (err.code === 'ER_DUP_ENTRY') {
            return res.status(409).json({ error: 'Email já cadastrado' })
        }
        res.status(500).json({ error: 'Erro ao atualizar fornecedor' })
    }
})

export default r